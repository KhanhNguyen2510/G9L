using G9L.Data.EFs;
using G9L.Data.Entities;
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
        //Create 
        public async Task<bool> CreateToImport(int ProviderID, int CompanyIndex, string UpdateUser)
        {
            try
            {
                var data = new Data.Entities.Import()
                {
                    ID = 0,
                    ImportDate = DateTime.Now,
                    ProviderID = ProviderID,
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

                var listImportDetails = new List<ImportDetails>();

                for (int i = 0; i <= request.ProductID.Length; i++)
                {
                    var rs = new ImportDetails()
                    {
                        ImportID = dummy.ID,
                        CostPrice = request.CostPrice[i],
                        ProductID = request.ProductID[i],
                        Quantily = request.Quantily[i],
                        IsUnit = request.IsUnit[i],

                        CompanyIndex = CompanyIndex,
                        UpdateDate = DateTime.Now,
                        UpdateUser = UpdateUser
                    };
                    listImportDetails.Add(rs);
                }
                _context.ImportDetails.AddRange(listImportDetails);

                await _context.SaveChangesAsync();

                await UpdateToImportByImportDetails(request.ImportID, CompanyIndex, UpdateUser);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //Update
        public async Task<bool> UpdateToImportByImportDetails(int ImportID, int CompanyIndex, string UpdateUser)
        {
            try
            {
                var result = await _context.ImportDetails.Where(x => x.ImportID == ImportID && x.CompanyIndex == CompanyIndex).Select(x => x.ProductID).ToListAsync();

                var rs = await _context.Products.Where(x => x.CompanyIndex == CompanyIndex).ToListAsync();

                decimal TotalAmount = 0;

                foreach (var item in result)
                {
                    TotalAmount += TotalAmount + rs.Where(x => x.ID == item).Select(x => x.Price).FirstOrDefault();
                }

                var card = new GetUpdateImportRequest()
                {
                    ImportID = ImportID,
                    TotalAmount = TotalAmount
                };

                await UpdateToImport(card, CompanyIndex, UpdateUser);

                return true;
            }
            catch
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

                rs.ImportDate = DateTime.Now;
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

                if (result != null)
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
                var rs = await _context.ImportDetails.Where(x => x.ImportID == request.ImportID && x.CompanyIndex == CompanyIndex).ToListAsync();

                var dummy = new List<ImportDetails>();

                foreach (var item in request.ListProductID)
                {
                    var data = rs.FirstOrDefault(x => x.ProductID == item);
                    dummy.Add(data);
                }

                _context.ImportDetails.RemoveRange(dummy);

                await _context.SaveChangesAsync();

                await UpdateToImportByImportDetails(request.ImportID, CompanyIndex, UpdateUser);
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
                        query = query.Where(x => x.ImportDate == request.DateTo).ToList();
                    else if (request.DateFrom != null && request.DateTo == null)
                        query = query.Where(x => x.ImportDate == request.DateFrom).ToList();
                    else
                        query = query.Where(x => request.DateFrom <= x.ImportDate && x.ImportDate <= request.DateTo).ToList();
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
        public async Task<List<GetImportDetailsViewModel>> GetListToImportDetails(int ImportID, int CompanyIndex)
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
    }
}
