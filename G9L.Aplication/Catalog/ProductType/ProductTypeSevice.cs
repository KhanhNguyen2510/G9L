using G9L.Data.EFs;
using G9L.Data.ViewModel.Catalog.ProductType;
using G9L.Data.ViewModel.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace G9L.Aplication.Catalog.ProductType
{
    public class ProductTypeSevice : IProductTypeSevice
    {
        private readonly G9LDbContext _context;

        public ProductTypeSevice(G9LDbContext context)
        {
            _context = context;
        }
        //Check
        //Create
        public async Task<bool> CreateToProductType(GetCreateProductTypeRequest request, int CompanyIndex, string UpdateUser)
        {
            try
            {
                var data = new Data.Entities.ProductType()
                {
                    ID = 0,
                    Name = !string.IsNullOrEmpty(request.Name) ? request.Name : "",
                    Image = !string.IsNullOrEmpty(request.Image) ? request.Image : "",

                    UpdateDate = DateTime.Now,
                    CompanyIndex = CompanyIndex,
                    UpdateUser = UpdateUser
                };
                _context.ProductTypes.Add(data);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                var d = ex.ToString();
                return false;
            }
        }
        //Update
        public async Task<bool> UpdateToProductType(GetUpdateProductTypeRequest request, int CompanyIndex, string UpdateUser)
        {
            try
            {
                var rs = await _context.ProductTypes.FirstOrDefaultAsync(x => x.ID == request.ProcductTypeID && x.CompanyIndex == CompanyIndex);

                if (rs == null) return false;

                rs.Name = !string.IsNullOrEmpty(request.ProcductTypeName) ? request.ProcductTypeName : rs.Name;
                rs.Image = !string.IsNullOrEmpty(request.Image) ? request.Image : rs.Image;

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
        public async Task<bool> DeleteToProductType(int ProductTypeID, int CompanyIndex)
        {
            try
            {
                var rs = await _context.ProductTypes.FirstOrDefaultAsync(x => x.ID == ProductTypeID && x.CompanyIndex == CompanyIndex);

                if (rs == null) return false;

                _context.ProductTypes.Remove(rs);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
        //List
        public async Task<PagedResult<GetProductTypeViewModel>> GetListToProductType(GetManagerProductTypeRequest request, int CompanyIndex)
        {
            try
            {
                var query = await _context.ProductTypes.Where(x => x.CompanyIndex == CompanyIndex).ToListAsync();

                if (request.KeyWord != null)
                    query = query.Where(x => x.Name.Contains(request.KeyWord) || x.ID.ToString().Contains(request.KeyWord)).ToList();
                int totalRow = query.Count;

                var data = query.Skip((request.PageIndex - 1) * request.PageSize)
                    .Take(request.PageSize).Select(x => new GetProductTypeViewModel()
                    {
                        ID = x.ID,
                        Name = x.Name,
                        Image = x.Image,
                        UpdateDate = x.UpdateDate,
                        UpdateUser = x.UpdateUser
                    }).ToList();

                var pagedResult = new PagedResult<GetProductTypeViewModel>()
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
        public async Task<GetProductTypeViewModel> GetToProductType(int ProductTypeID, int CompanyIndex)
        {
            try
            {
                var query = await _context.ProductTypes.Where(x => x.CompanyIndex == CompanyIndex && x.ID == ProductTypeID).FirstOrDefaultAsync();

                var data = new GetProductTypeViewModel()
                {
                    ID = query.ID,
                    Name = query.Name,
                    Image = query.Image,
                    UpdateDate = query.UpdateDate,
                    UpdateUser = query.UpdateUser
                };

                return data;
            }
            catch
            {
                return null;
            }
        }

        public async Task<List<GetProducType>> GetToProducTypeOnNameAndID(int CompanyIndex)
        {
            try
            {
                var data = await _context.ProductTypes.Where(x => x.CompanyIndex == CompanyIndex).Select(x =>
             new GetProducType()
             {
                 ProducTypeID = x.ID,
                 ProducTypeName = x.Name
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
