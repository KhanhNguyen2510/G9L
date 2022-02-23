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

        public ExportSevice(G9LDbContext context)
        {
            _context = context;
        }
        //Check

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
        
        public async Task<bool> CreateToExportDetails(GetCreateExportDetailsRequest request, int CompanyIndex, string UpdateUser)
        {
            try
            {
                var dummy = await _context.Exports.FirstOrDefaultAsync(x=>x.ID == request.ExportID && x.CompanyIndex == CompanyIndex);

                if (dummy == null) return false;

                var listExportDetails = new List<ExportDetails>();

                foreach (var item in request.ProductID)
                {
                    var data = new ExportDetails()
                    {
                        ExportID = dummy.ID,
                        ProductID = item,
                        CompanyIndex = CompanyIndex,
                        UpdateDate = DateTime.Now,
                        UpdateUser = UpdateUser
                    };
                    listExportDetails.Add(data);
                }
                _context.ExportDetails.AddRange(listExportDetails);
                await _context.SaveChangesAsync();

                await UpdateToExportByExportDetails(request.ExportID, CompanyIndex , UpdateUser);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        //Update

        public async Task<bool> UpdateToExportByExportDetails(int ExportID, int CompanyIndex, string UpdateUser)
        {
            try
            {
                var result = await _context.ExportDetails.Where(x => x.ExportID == ExportID && x.CompanyIndex == CompanyIndex).Select(x => x.ProductID).ToListAsync();

                var rs = await _context.Products.Where(x => x.CompanyIndex == CompanyIndex).ToListAsync();

                decimal TotalAmount = 0;

                foreach (var item in result)
                {
                    TotalAmount += TotalAmount + rs.Where(x => x.ID == item).Select(x => x.Price).FirstOrDefault();
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
                
                if(result != null)
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

        public async Task<bool> DeleteToExportDetails(GetDeleteToExportDetails request , int CompanyIndex, string UpdateUser)
        {
            try
            {
                var rs = await _context.ExportDetails.Where(x => x.ExportID == request.ExportID && x.CompanyIndex == CompanyIndex).ToListAsync();

                var dummy = new List<ExportDetails>();

                foreach (var item in request.ListProductID)
                {
                    var data = rs.FirstOrDefault(x => x.ProductID == item);
                    dummy.Add(data);
                }

                _context.ExportDetails.RemoveRange(dummy);
                await _context.SaveChangesAsync();
                await UpdateToExportByExportDetails(request.ExportID, CompanyIndex, UpdateUser);
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
