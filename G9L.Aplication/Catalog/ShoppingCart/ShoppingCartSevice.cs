using G9L.Data.EFs;
using G9L.Data.ViewModel.Catalog.ShoppingCart;
using G9L.Data.ViewModel.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace G9L.Aplication.Catalog.ShoppingCart
{
    public class ShoppingCartSevice : IShoppingCartSevice
    {
        private readonly G9LDbContext _context;
        public ShoppingCartSevice(G9LDbContext context)
        {
            _context = context;
        }
        //Check 
        //Create 
        public async Task<bool> CreateOrUpdateToShoppingCart(GetCreateToShoppingCartRequest request, int CompanyIndex, string UpdateUser)
        {
            try
            {
                var rs = await _context.ShoppingCarts.FirstOrDefaultAsync(x => x.ProductID == request.ProductID && x.CompanyIndex == CompanyIndex);

                if (rs != null)
                {
                    rs.Quantily = (int)(rs.Quantily + request.Quantily);
                    rs.IsUnit = (Data.Enum.IsUnit)(request.IsUnit != null ? request.IsUnit : rs.IsUnit);

                    rs.CompanyIndex = CompanyIndex;
                    rs.UpdateDate = DateTime.Now;
                    rs.UpdateUser = UpdateUser;
                    await _context.SaveChangesAsync();
                    return true;
                }
                else if (rs == null)
                {
                    var data = new Data.Entities.ShoppingCart()
                    {
                        ProductID = request.ProductID,
                        Quantily = (int)(request.Quantily != null ? request.Quantily : 0),
                        DateCreate = DateTime.Now,
                        IsUnit = (Data.Enum.IsUnit)(request.IsUnit != null ? request.IsUnit : Data.Enum.IsUnit.Item),

                        CompanyIndex = CompanyIndex,
                        UpdateDate = DateTime.Now,
                        UpdateUser = UpdateUser
                    };

                    _context.ShoppingCarts.Add(data);
                    await _context.SaveChangesAsync();

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
        //Update
        //Delete
        public async Task<bool> DeleteToShoppingCart(int ProductID, int CompanyIndex)
        {
            try
            {
                var rs = await _context.ShoppingCarts.FirstOrDefaultAsync(x => x.ProductID == ProductID && x.CompanyIndex == CompanyIndex);

                if (rs == null) return false;

                _context.ShoppingCarts.Remove(rs);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteAllToShoppingCart(int CompanyIndex)
        {
            try
            {
                var data = await _context.ShoppingCarts.Where(x => x.CompanyIndex == CompanyIndex).ToListAsync();

                if (data == null) return false;

                _context.ShoppingCarts.RemoveRange(data);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
        //List
        public async Task<PagedResult<GetShoppingCartViewModel>> GetListToShoppingCart(PagingRequestBase request, int CompanyIndex)
        {
            try
            {
                var query = await (
                                     from i in _context.ShoppingCarts
                                     join p in _context.Products
                                     on i.ProductID equals p.ID
                                     where i.CompanyIndex == CompanyIndex
                                     select new
                                     {
                                         p.ID,
                                         p.Name,
                                         i.Quantily,
                                         i.IsUnit,
                                         i.DateCreate,
                                         i.UpdateUser
                                     }).ToListAsync();

                int totalRow = query.Count;

                var data = query.Skip((request.PageIndex - 1) * request.PageSize)
                    .Take(request.PageSize).Select(x => new GetShoppingCartViewModel()
                    {
                        ProductID = x.ID,
                        ProductName = x.Name,
                        DateCreate = x.DateCreate,
                        Quantily = x.Quantily,
                        IsUnit = x.IsUnit,
                        UpdateUser = x.UpdateUser
                    }).ToList();

                var pagedResult = new PagedResult<GetShoppingCartViewModel>()
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
