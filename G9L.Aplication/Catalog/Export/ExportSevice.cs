using G9L.Aplication.Catalog.ShoppingCart;
using G9L.Data.EFs;
using G9L.Data.Entities;
using G9L.Data.Enum;
using G9L.Data.ViewModel.Catalog.Export;
using G9L.Data.ViewModel.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace G9L.Aplication.Catalog.Export
{
    public class ExportSevice : IExportSevice
    {
        private readonly G9LDbContext _context;
        private readonly IShoppingCartSevice _shoppingCartSevice;

        public ExportSevice(G9LDbContext context, IShoppingCartSevice shoppingCartSevice)
        {
            _context = context;
            _shoppingCartSevice = shoppingCartSevice;
        }
        //Check
        public async Task<bool> MinusQuantilyProduct(int ExportID, int ProductID, int CompanyIndex)
        {
            try
            {
                var rs = await _context.ExportDetails.FirstOrDefaultAsync(x => x.ExportID == ExportID && x.ProductID == ProductID);
                var result = await _context.Products.FirstOrDefaultAsync(x => x.ID == rs.ProductID && x.CompanyIndex == CompanyIndex);
                var data = await _context.UnitProducts.FirstOrDefaultAsync(x => x.ProductID == ProductID);
                if (rs == null || result == null || data == null) return false;

                if (rs.IsUnit == IsUnit.Barrel)
                {
                    int numberProduct = data.NumberInBarrel * rs.Quantily;

                    result.Quantily = result.Quantily - numberProduct;
                }
                else
                {
                    result.Quantily = result.Quantily - rs.Quantily;
                }
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
        //Create
        public async Task<bool> CreateToExport(int CompanyIndex, string UpdateUser)
        {
            try
            {
                var data = new Data.Entities.Export()
                {
                    ID = 0,
                    ExportDate = DateTime.Now,
                    TotalAmount = 0,
                    IsExport = IsExport.UnSuccessExport,

                    UpdateDate = DateTime.Now,
                    CompanyIndex = CompanyIndex,
                    UpdateUser = UpdateUser
                };
                _context.Exports.Add(data);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<int> AddShoppingCartInExport(int CompanyIndex, string UpdateUser)
        {
            try
            {
                var data = await _context.ShoppingCarts.Where(x => x.CompanyIndex == CompanyIndex).ToListAsync();

                if (data.Any())
                {
                    await CreateToExport(CompanyIndex, UpdateUser);

                    var rs = await _context.Exports.Where(x => x.CompanyIndex == CompanyIndex).OrderByDescending(x => x.ID).Select(x => x.ID).FirstOrDefaultAsync();

                    foreach (var item in data)
                    {
                        var resul = new GetCreateExportDetailsRequest()
                        {
                            ExportID = rs,
                            ProductID = item.ProductID,
                            Quantily = item.Quantily,
                            IsUnit = item.IsUnit
                        };
                        var dummy = await CreateToExportDetails(resul, CompanyIndex, UpdateUser);
                        if (dummy is (int)CheckProductInWarehouse.OutOfStock or (int)CheckProductInWarehouse.Undiscovered)
                        {
                            return dummy;
                        }
                    }
                    await _shoppingCartSevice.DeleteAllToShoppingCart(CompanyIndex);

                    return (int)CheckProductInWarehouse.Successful;
                }

                return (int)CheckProductInWarehouse.Undiscovered;
            }
            catch
            {
                return (int)CheckProductInWarehouse.Undiscovered;
            }
        }

        public async Task<int> CreateToExportDetails(GetCreateExportDetailsRequest request, int CompanyIndex, string UpdateUser)
        {
            try
            {
                var dummy = await _context.Exports.FirstOrDefaultAsync(x => x.ID == request.ExportID && x.CompanyIndex == CompanyIndex);

                if (dummy == null) return (int)CheckProductInWarehouse.Undiscovered;

                var data = new ExportDetails()
                {
                    ExportID = request.ExportID,
                    ProductID = request.ProductID,
                    Quantily = request.Quantily,
                    IsUnit = request.IsUnit ,

                    CompanyIndex = CompanyIndex,
                    UpdateDate = DateTime.Now,
                    UpdateUser = UpdateUser
                };

                _context.ExportDetails.Add(data);
                await _context.SaveChangesAsync();

                var card = await UpdateQuantilyInProductByExportID(request.ExportID, request.ProductID, CompanyIndex, UpdateUser); //update Quantily of Product 
                if (card != CheckProductInWarehouse.Undiscovered)
                {
                    return (int)card;
                }
                await UpdateTotalAmountInExportByExportID(request.ExportID, CompanyIndex, UpdateUser); // update Totalamount of ExportID

                return (int)CheckProductInWarehouse.Successful;
            }
            catch (Exception)
            {
                return (int)CheckProductInWarehouse.Undiscovered;
            }
        }
        //Update

        public async Task<CheckProductInWarehouse> UpdateQuantilyInProductByExportID(int ExportID ,int ProductID, int CompanyIndex, string UpdateUser)
        {
            try
            {
                var rs = await _context.ExportDetails.FirstOrDefaultAsync(x => x.ExportID == ExportID && x.ProductID == ProductID && x.CompanyIndex == CompanyIndex);
                var result = await _context.Products.FirstOrDefaultAsync(x => x.CompanyIndex == CompanyIndex && x.ID == ProductID);
                var data = await _context.UnitProducts.FirstOrDefaultAsync(x => x.ProductID == ProductID);
                if (rs == null || result == null || data == null ) return CheckProductInWarehouse.Undiscovered;

                if (result.Quantily == 0)
                {
                    return CheckProductInWarehouse.OutOfStock;
                }
                else
                {
                    if (rs.IsUnit == IsUnit.Barrel)
                    {
                        int numberProduct = data.NumberInBarrel * rs.Quantily;

                        if (numberProduct > result.Quantily )
                        {
                            return CheckProductInWarehouse.InsufficientOfStock;
                        }

                        result.Quantily = result.Quantily - numberProduct;
                    }
                    else
                    {
                        if (rs.Quantily > result.Quantily)
                        {
                            return CheckProductInWarehouse.InsufficientOfStock;
                        }
                        result.Quantily = result.Quantily - rs.Quantily;
                    }
                    result.UpdateDate = DateTime.Now;
                    result.UpdateUser = UpdateUser;

                    await _context.SaveChangesAsync();
                    return CheckProductInWarehouse.SuccessfulSales;
                }
            }
            catch
            {
                return CheckProductInWarehouse.Undiscovered;
            }
        }

        public async Task<bool> UpdateTotalAmountInExportByExportID(int ExportID, int CompanyIndex, string UpdateUser)
        {
            try
            {
                var result = await _context.ExportDetails.Where(x => x.ExportID == ExportID && x.CompanyIndex == CompanyIndex).Select(x => new { x.ProductID, x.Quantily, x.IsUnit}).ToListAsync();

                var rs = await _context.Products.Where(x => x.CompanyIndex == CompanyIndex).ToListAsync();
                var data = await _context.UnitProducts.ToListAsync();

                if (rs == null || result == null || data == null) return false;

                decimal TotalAmount = 0;

                foreach (var item in result)
                {
                    var priceProduct = rs.Where(x => x.ID == item.ProductID).Select(x => x.Price).FirstOrDefault();

                    if (item.IsUnit == IsUnit.Barrel)
                    {
                        var numberInBarrel = data.Where(x => x.ProductID == item.ProductID).Select(x => x.NumberInBarrel).FirstOrDefault();

                        int numberProduct =  numberInBarrel * item.Quantily;

                        TotalAmount = TotalAmount + priceProduct * numberProduct;
                    }
                    else
                    {
                        TotalAmount = TotalAmount + priceProduct * item.Quantily;
                    }
                }

                var card = new GetUpdateExportRequest()
                {
                    ExportID = ExportID,
                    TotalAmount = TotalAmount
                };

                await UpdateToExport(card, CompanyIndex, UpdateUser);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> UpdateToExport(GetUpdateExportRequest request , int CompanyIndex, string UpdateUser)
        {
            try
            {
                var rs = await _context.Exports.FirstOrDefaultAsync(x => x.ID == request.ExportID && x.CompanyIndex == CompanyIndex);

                if (rs == null) return false;

                rs.ExportDate = DateTime.Now;
                rs.TotalAmount = (decimal)(request.TotalAmount != null ? request.TotalAmount : rs.TotalAmount);

                rs.UpdateUser = !string.IsNullOrEmpty(UpdateUser) ? UpdateUser : rs.UpdateUser;
                rs.UpdateDate = DateTime.Now;

                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
        //Delete
        public async Task<bool> DeleteToExport(int ExportID , int CompanyIndex)
        {
            try
            {
                var rs = await _context.Exports.FirstOrDefaultAsync(x => x.ID == ExportID && x.CompanyIndex == CompanyIndex);
                
                if (rs == null) return false;

                var result = await _context.ExportDetails.Where(x => x.ExportID == ExportID && x.CompanyIndex == CompanyIndex).ToListAsync();
                
                if(result.Any()) 
                    _context.ExportDetails.RemoveRange(result);
                
                _context.Exports.Remove(rs);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteToExportDetails(GetDeleteToExportDetails request , int CompanyIndex , string UpdateUser)
        {
            try
            {
                var rs = await _context.ExportDetails.FirstOrDefaultAsync(x => x.ExportID == request.ExportID && x.ProductID == request.ProductID && x.CompanyIndex == CompanyIndex);

                if (rs == null) return false;

                var check = await MinusQuantilyProduct(request.ExportID, request.ProductID, CompanyIndex);
                if (check == false) return false;

                _context.ExportDetails.Remove(rs);

                await _context.SaveChangesAsync();

                await UpdateTotalAmountInExportByExportID(request.ExportID, CompanyIndex, UpdateUser); // update Totalamount of ExportID

                return true;
            }
            catch
            {
                return false;
            }
        }
        //List
        public async Task<PagedResult<GetExportViewModel>> GetListToExport(GetManagerExportRequest request , int CompanyIndex)
        {
            try
            {
                var query = await _context.Exports.Where(x => x.CompanyIndex == CompanyIndex).ToListAsync();

                if (request.KeyWord != null)
                    query = query.Where(x => x.ID.ToString().Contains(request.KeyWord)).ToList();

                if (request.IsExport != null)
                    query = query.Where(x => x.IsExport == request.IsExport).ToList();

                if (request.DateFrom != null || request.DateTo != null)
                {
                    if (request.DateFrom == null && request.DateTo != null)
                        query = query.Where(x => x.ExportDate.Date == request.DateTo.Value.Date).ToList();
                    else if (request.DateFrom != null && request.DateTo == null)
                        query = query.Where(x => x.ExportDate.Date == request.DateFrom.Value.Date).ToList();
                    else
                        query = query.Where(x => request.DateFrom.Value.Date <= x.ExportDate.Date && x.ExportDate.Date <= request.DateTo.Value.Date).ToList();
                }

                int totalRow = query.Count;

                var data = query.Skip((request.PageIndex - 1) * request.PageSize)
                    .Take(request.PageSize).Select(x => new GetExportViewModel()
                    {
                        ID = x.ID,
                        ExportDate = x.ExportDate,
                        TotalAmount = x.TotalAmount,
                        IsExport = x.IsExport,
                        UpdateDate = x.UpdateDate,
                        UpdateUser = x.UpdateUser
                    }).ToList();

                var pagedResult = new PagedResult<GetExportViewModel>()
                {
                    TotalRecords = totalRow,
                    PageIndex = request.PageIndex,
                    PageSize = request.PageSize,
                    Items = data
                };
                return pagedResult;
            }
            catch
            {
                return null;
            }
        }

        public async Task<List<GetExportDetailsViewModel>> GetListToExportDetails(int ExportID, int CompanyIndex)
        {
            var data = await ( from ed in _context.ExportDetails
                              join e in _context.Products
                              on ed.ProductID equals e.ID
                              where ed.ExportID == ExportID && ed.CompanyIndex == CompanyIndex
                              select new GetExportDetailsViewModel()
                              {
                                  ExportID = ed.ExportID,
                                  ProductID = ed.ProductID,
                                  Price = e.Price,
                                  ProductName = e.Name,
                                  Quantity = e.Quantily
                              }).ToListAsync();
            return data;
        }
    }
}
