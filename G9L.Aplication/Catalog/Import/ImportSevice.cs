using G9L.Data.EFs;
using G9L.Data.Entities;
using G9L.Data.Enum;
using G9L.Data.ViewModel.Catalog.Import;
using G9L.Data.ViewModel.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace G9L.Aplication.Catalog.Import
{
    public class ImportSevice : IImportSevice
    {
        private readonly G9LDbContext _context;
        public ImportSevice(G9LDbContext context)
        {
            _context = context;
        }
        //Check 
        public async Task<bool> MinusQuantilyProduct(int ImportID, int ProductID, int CompanyIndex)
        {
            try
            {
                var rs = await _context.ImportDetails.FirstOrDefaultAsync(x => x.ImportID == ImportID && x.ProductID == ProductID);
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
        public async Task<bool> CreateToImport(int? ProviderID,  int CompanyIndex, string UpdateUser)
        {
            try
            {
                var data = new Data.Entities.Import()
                {
                    ID = 0,
                    ImportDate = DateTime.Now,
                    ProviderID = (int)(ProviderID != null? ProviderID : 0),
                    TotalAmount = 0,
                    UpdateDate = DateTime.Now,
                    CompanyIndex = CompanyIndex,
                    UpdateUser = UpdateUser
                };
                _context.Imports.Add(data);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> CreateToImportDetails(GetCreateImportDetailsRequest request, int CompanyIndex, string UpdateUser)
        {
            try
            {
                var dummy = await _context.Imports.FirstOrDefaultAsync(x => x.ID == request.ImportID && x.CompanyIndex == CompanyIndex);

                if (dummy == null) return false;

                var rs = new ImportDetails()
                {
                    ImportID = dummy.ID,
                    CostPrice = request.CostPrice,
                    IsUnit = request.IsUnit,
                    ProductID = request.ProductID,
                    Quantily = request.Quantily,

                    CompanyIndex = CompanyIndex,
                    UpdateDate = DateTime.Now,
                    UpdateUser = UpdateUser
                };

                _context.ImportDetails.Add(rs);

                await _context.SaveChangesAsync();

                await UpdateTotalAmountInImportByImportID(request.ImportID, CompanyIndex, UpdateUser);//update Totalamount of ImportID

                await UpdateCostPriceAndQuantilyInProductByImportID(request.ImportID, request.ProductID, CompanyIndex, UpdateUser); //update Quantily and Price of Product 

                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }

        //Update

        

        public async Task<bool> UpdateImportDetailByID(GetUpdateToImportDetailsRequest request, int CompanyIndex, string UpdateUser)
        {
            try
            {
                var rs = await _context.ImportDetails.FirstOrDefaultAsync(x => x.ImportID == request.ImportID && x.ProductID == request.ProductID);
                if (rs == null) return false;

                var check = await MinusQuantilyProduct(request.ImportID, request.ProductID, CompanyIndex);
                if (check == false) return false;

                rs.Quantily = (int)(request.Quantily != null ? request.Quantily : rs.Quantily);
                rs.CostPrice = (decimal)(request.CostPrice != null ? request.CostPrice : rs.CostPrice);
                rs.IsUnit = (IsUnit)(request.IsUnit != null ? request.IsUnit : rs.IsUnit);

                await _context.SaveChangesAsync();

                await UpdateTotalAmountInImportByImportID(request.ImportID, CompanyIndex, UpdateUser);//update Totalamount of ImportID

                await UpdateCostPriceAndQuantilyInProductByImportID(request.ImportID, request.ProductID, CompanyIndex, UpdateUser); //update Quantily and Price of Product 

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> UpdateCostPriceAndQuantilyInProductByImportID(int ImportID, int ProductID,  int CompanyIndex, string UpdateUser)
        {
            try
            {
                var rs = await _context.ImportDetails.FirstOrDefaultAsync(x => x.ImportID == ImportID && x.ProductID == ProductID && x.CompanyIndex == CompanyIndex);

                var result = await _context.Products.FirstOrDefaultAsync(x => x.CompanyIndex == CompanyIndex && x.ID == ProductID);

                var data = await _context.UnitProducts.FirstOrDefaultAsync(x => x.ProductID == ProductID);

                if (rs == null || result == null || data == null) return false;

                result.OldPrice += result.CostPrice + ","; // Save  Old Cost Price 

                ///Check Total by IsUnit 
                if (rs.IsUnit == IsUnit.Barrel)
                {
                    int numberProduct = data.NumberInBarrel * rs.Quantily;

                    result.Quantily = numberProduct + result.Quantily;

                    result.CostPrice = rs.CostPrice / numberProduct; // Đổi giá khi nhập hàng
                }
                else
                {
                    result.Quantily = rs.Quantily + result.Quantily;

                    result.CostPrice = rs.CostPrice / result.Quantily;
                }

                result.UpdateUser = UpdateUser;
                result.UpdateDate = DateTime.Now;

                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> UpdateTotalAmountInImportByImportID(int ImportID, int CompanyIndex, string UpdateUser)
        {
            try
            {
                var result = await _context.ImportDetails.Where(x => x.ImportID == ImportID && x.CompanyIndex == CompanyIndex).ToListAsync();
                
                var rs = await _context.Products.Where(x => x.CompanyIndex == CompanyIndex).ToListAsync();

                decimal TotalAmount = 0;
               
                foreach (var item in result)
                {
                    TotalAmount = TotalAmount + item.CostPrice;
                }

                var card = new GetUpdateImportRequest()
                {
                    ImportID = ImportID,
                    TotalAmount = TotalAmount
                };

                await UpdateToImport(card, CompanyIndex, UpdateUser);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> UpdateToImport(GetUpdateImportRequest request, int CompanyIndex, string UpdateUser)
        {
            try
            {
                var rs = await _context.Imports.FirstOrDefaultAsync(x => x.ID == request.ImportID && x.CompanyIndex == CompanyIndex);

                if (rs == null) return false;

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
        public async Task<bool> DeleteToImport(int ImportID, int CompanyIndex)
        {
            try
            {
                var rs = await _context.Imports.FirstOrDefaultAsync(x => x.ID == ImportID && x.CompanyIndex == CompanyIndex);

                if (rs == null) return false;

                var result = await _context.ImportDetails.Where(x => x.ImportID == ImportID && x.CompanyIndex == CompanyIndex).ToListAsync();

                if (result.Count > 0)
                    _context.ImportDetails.RemoveRange(result);

                _context.Imports.Remove(rs);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteToExportDetails(GetDeleteToImportDetails request, int CompanyIndex, string UpdateUser)
        {
            try
            {
                var rs = await _context.ImportDetails.FirstOrDefaultAsync(x => x.ProductID == request.ProductID && x.ImportID == request.ImportID && x.CompanyIndex == CompanyIndex);



                if (rs == null) return false;

                var check = await MinusQuantilyProduct(request.ImportID, request.ProductID, CompanyIndex);
                if (check == false) return false;

                _context.ImportDetails.Remove(rs);

                await _context.SaveChangesAsync();

                await UpdateTotalAmountInImportByImportID(request.ImportID, CompanyIndex, UpdateUser);//update Totalamount of ImportID

              

                return true;
            }
            catch
            {
                return false;
            }
        }
        
        //List
        public async Task<PagedResult<GetImportViewModel>> GetListToImport(GetManagerImportRequest request, int CompanyIndex)
        {
            try
            {
                var query = await ( from i in _context.Imports
                                   join p in _context.Providers
                                   on i.ProviderID equals p.ID
                                   into pt from p in pt.DefaultIfEmpty()
                                    where i.CompanyIndex == CompanyIndex
                                   select new
                                   {
                                       i.ID,
                                       i.ImportDate,
                                       i.TotalAmount,
                                       p.Name,
                                       i.ProviderID,
                                       i.UpdateDate,
                                       i.UpdateUser
                                   }).ToListAsync();

                if (request.KeyWord != null)
                    query = query.Where(x => x.ID.ToString().Contains(request.KeyWord)).ToList();

                if (request.ProviderID != null)
                    query = query.Where(x => x.ProviderID == request.ProviderID).ToList();

                if (request.DateFrom != null || request.DateTo != null)
                {
                    if (request.DateFrom == null && request.DateTo != null)
                        query = query.Where(x => x.ImportDate == request.DateTo.Value.Date).ToList();
                    else if (request.DateFrom != null && request.DateTo == null)
                        query = query.Where(x => x.ImportDate == request.DateFrom.Value.Date).ToList();
                    else
                        query = query.Where(x => request.DateFrom.Value.Date <= x.ImportDate && x.ImportDate <= request.DateTo.Value.Date).ToList();
                }

                int totalRow = query.Count;

                var data = query.Skip((request.PageIndex - 1) * request.PageSize)
                    .Take(request.PageSize).Select(x => new GetImportViewModel()
                    {
                        ID = x.ID,
                        ImportDate = x.ImportDate,
                        TotalAmount = x.TotalAmount,
                        ProviderName = x.Name,
                        UpdateDate = x.UpdateDate,
                        UpdateUser = x.UpdateUser
                    }).ToList();

                var pagedResult = new PagedResult<GetImportViewModel>()
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

        public async Task<GetImportFinal> GetImportFinalID(int CompanyIndex)
        {
            try
            {
                var query = await _context.Imports.Where(x => x.CompanyIndex == CompanyIndex).OrderByDescending(x => x.ID).FirstOrDefaultAsync();

                if (query == null) return null;

                var data = new GetImportFinal()
                {
                    ID = query.ID,
                    ImportDate = query.ImportDate
                };

                return data;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public async Task<List<GetImportDetailsViewModel>> GetListToImportDetails(int ImportID, int CompanyIndex)
        {
            try
            {
                var data = await (from id in _context.ImportDetails
                                  join p in _context.Products
                                  on id.ProductID equals p.ID
                                  where id.ImportID == ImportID && id.CompanyIndex == CompanyIndex
                                  select new GetImportDetailsViewModel()
                                  {
                                      ImportID = id.ImportID,
                                      ProductID = id.ProductID,
                                      ProductName = p.Name,
                                      CostPrice = id.CostPrice,
                                      IsUnit = id.IsUnit,
                                      Quantily = id.Quantily
                                  }).ToListAsync();

                return data;
            }
            catch
            {
                return null;
            }
        }
    }
}
