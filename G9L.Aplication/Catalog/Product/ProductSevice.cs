using G9L.Common.Sevices;
using G9L.Data.EFs;
using G9L.Data.ViewModel.Catalog.Product;
using G9L.Data.ViewModel.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace G9L.Aplication.Catalog.Product
{
    public class ProductSevice : IProductSevice
    {
        private readonly G9LDbContext _context;

        public ProductSevice(G9LDbContext context)
        {
            _context = context;
        }
        //Check
        //Create
        public async Task<bool> CreateToProvider(GetCreateProductRequest request, int CompanyIndex, string UpdateUser)
        {
            try
            {
                var data = new Data.Entities.Product()
                {
                    ID = 0,
                    Name = !string.IsNullOrEmpty(request.ProductName) ? request.ProductName : "",
                    CostPrice = 0,
                    Price = (decimal)(request.Price != null ? request.Price : 0),
                    ManufactureID = (int)(request.ManufactureID != null ? request.ManufactureID : null),
                    Quantily = (int)(request.Quantily != null ? request.Quantily : 0),
                    StorageLocations = !string.IsNullOrEmpty(request.StorageLocations) ? request.StorageLocations : "",
                    Description = !string.IsNullOrEmpty(request.Description) ? request.Description : "",
                   
                    UpdateDate = DateTime.Now,
                    CompanyIndex = CompanyIndex,
                    UpdateUser = UpdateUser
                };
                _context.Products.Add(data);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        //Update
        public async Task<bool> UpdateToProvider(GetUpdateProductRequest request, int CompanyIndex, string UpdateUser)
        {
            try
            {
                var rs = await _context.Products.FirstOrDefaultAsync(x => x.ID == request.ProductID && x.CompanyIndex == CompanyIndex);

                if (rs == null) return false;

                rs.Name = !string.IsNullOrEmpty(request.ProductName) ? request.ProductName : rs.Name;
                rs.ManufactureID = (int)(request.ManufactureID != null ? request.ManufactureID : rs.ManufactureID);
                rs.Price = (decimal)(request.Price != null ? request.Price : rs.Price);
                rs.Quantily = (int)(request.Quantily != null ? request.Quantily : rs.Quantily);
                rs.StorageLocations = !string.IsNullOrEmpty(request.StorageLocations) ? request.StorageLocations : rs.StorageLocations;
                rs.Description = !string.IsNullOrEmpty(request.Description) ? request.Description : rs.Description;

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
        public async Task<bool> DeleteToProduct(int ProductID, int CompanyIndex)
        {
            try
            {
                var rs = await _context.Products.FirstOrDefaultAsync(x => x.ID == ProductID && x.CompanyIndex == CompanyIndex);

                if (rs == null) return false;

                _context.Products.Remove(rs);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
        //List
        public async Task<PagedResult<GetManagerProductViewModel>> GetListToProduct(GetManagerProductRequest request , int CompanyIndex)
        {
            try
            {
                var query = await (from p in _context.Products
                             join m in _context.Manufactures
                             on p.ManufactureID equals m.ID
                             where p.CompanyIndex == CompanyIndex
                             select new
                             {
                                 p.ID,
                                 p.Name,
                                 p.CostPrice,
                                 p.Description,
                                 p.StorageLocations,
                                 m.Local,
                                 ManufactureName = m.Name,
                                 p.Price,
                                 p.Quantily,
                                 ManufactureID = m.ID
                             }).ToListAsync();

                if (request.KeyWord != null)
                    query = query.Where(x => x.ID.ToString().Contains(request.KeyWord) || x.Name.Contains(request.KeyWord) || x.Description.Contains(request.KeyWord)).ToList();

                if (request.ManufactureID != null)
                    query = query.Where(x => x.ManufactureID == request.ManufactureID).ToList();

                if (request.StorageLocations != null)
                    query = query.Where(x => x.StorageLocations == request.StorageLocations).ToList();

                int totalRow = query.Count;

                var data = query.Skip((request.PageIndex - 1) * request.PageSize)
                    .Take(request.PageSize).Select(x => new GetManagerProductViewModel()
                    {
                        ID = x.ID,
                        Name = x.Name,
                        CostPrice = x.CostPrice,
                        Description = x.Description,
                        StorageLocations = x.StorageLocations,
                        Local = x.Local,
                        ManufactureName = x.ManufactureName,
                        Price = x.Price,
                        Quantily = x.Quantily,
                    }).ToList();

                var pagedResult = new PagedResult<GetManagerProductViewModel>()
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

    }
}
