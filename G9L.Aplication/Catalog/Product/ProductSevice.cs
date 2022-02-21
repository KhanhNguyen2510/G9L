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
        public async Task<bool> CreateToProduct(GetCreateProductRequest request, int CompanyIndex, string UpdateUser)
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
                    ProductTypeID = request.ProductTypeID,
                    Image1 = !string.IsNullOrEmpty(request.Image1)? request.Image1:"",
                    Image2 = !string.IsNullOrEmpty(request.Image2) ? request.Image2 : "",
                    Image3 = !string.IsNullOrEmpty(request.Image3) ? request.Image3 : "",

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
        public async Task<bool> UpdateToProduct(GetUpdateProductRequest request, int CompanyIndex, string UpdateUser)
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
                rs.ProductTypeID = (int)(request.ProductTypeID != null ? request.ProductTypeID : rs.ProductTypeID);
                rs.Image1 = !string.IsNullOrEmpty(request.Image1) ? request.Image1 : rs.Image1;
                rs.Image2 = !string.IsNullOrEmpty(request.Image2) ? request.Image2 : rs.Image2;
                rs.Image3 = !string.IsNullOrEmpty(request.Image3) ? request.Image3 : rs.Image3;

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
                                   join pt in _context.ProductTypes
                                   on p.ProductTypeID equals pt.ID
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
                                       ManufactureID = m.ID,
                                       ProcductTypeName = pt.Name,
                                       ProductTypeID = pt.ID,
                                       p.Image1,
                                       p.Image2,
                                       p.Image3
                                   }).ToListAsync();

                if (request.KeyWord != null)
                    query = query.Where(x => x.ID.ToString().Contains(request.KeyWord) || x.Name.ToLower().Contains(request.KeyWord.ToLower()) || x.Description.ToLower().Contains(request.KeyWord.ToLower())).ToList();

                if (request.ManufactureID != null)
                    query = query.Where(x => x.ManufactureID == request.ManufactureID).ToList();

                if (request.ProductTypeID != null)
                    query = query.Where(x => x.ProductTypeID == request.ProductTypeID).ToList();

                if (request.StorageLocations != null)
                    query = query.Where(x => x.StorageLocations.ToLower() == request.StorageLocations.ToLower()).ToList();

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
                        ProductTypeName = x.ProcductTypeName,
                        Image1 = x.Image1,
                        Image2 = x.Image2,
                        Image3 = x.Image3
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
        public async Task<GetManagerProductViewModel> GetToProduct(int ProductID, int CompanyIndex)
        {
            try
            {
                var query = await (from p in _context.Products
                                   join m in _context.Manufactures
                                   on p.ManufactureID equals m.ID
                                   join pt in _context.ProductTypes
                                   on p.ProductTypeID equals pt.ID
                                   where p.CompanyIndex == CompanyIndex && p.ID == ProductID
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
                                       ManufactureID = m.ID,
                                       ProcductTypeName = pt.Name,
                                       ProductTypeID = pt.ID,
                                       p.Image1,
                                       p.Image2,
                                       p.Image3
                                   }).FirstOrDefaultAsync();

                var data = new GetManagerProductViewModel()
                {
                    ID = query.ID,
                    Name = query.Name,
                    CostPrice = query.CostPrice,
                    Description = query.Description,
                    StorageLocations = query.StorageLocations,
                    Local = query.Local,
                    ManufactureName = query.ManufactureName,
                    Price = query.Price,
                    Quantily = query.Quantily,
                    ProductTypeName = query.ProcductTypeName,
                    Image1 = query.Image1,
                    Image2 = query.Image2,
                    Image3 = query.Image3,
                    ManufactureID = query.ManufactureID,
                    ProductTypeID = query.ProductTypeID
                };

                return data;
            }
            catch
            {
                return null;
            }
        }
        public async Task<List<GetProduct>> GetToProductToNameAndID(int CompanyIndex)
        {
            try
            {
                var data = await _context.Products.Where(x => x.CompanyIndex == CompanyIndex).Select(x => new GetProduct()
                {
                    ProductID = x.ID,
                    ProductName = x.Name
                }).ToListAsync();

                return data;
            }
            catch
            {
                return null;
            }
        }
        public async Task<List<GetProductByName>> GetToProductToName(int CompanyIndex)
        {
            var data = await _context.Products.Where(x => x.CompanyIndex == CompanyIndex).Select(x => x.StorageLocations).Distinct().ToListAsync();

            var rs = data.Select(x => new GetProductByName()
            {
                ProductName = x
            }).ToList();

            return rs;
        }
    }
}
