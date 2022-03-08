using G9L.Data.EFs;
using G9L.Data.ViewModel.Catalog.ShoppingCart;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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

        //Count
        public async Task<decimal> TotalAmountToShoppingCard(int CompanyIndex)
        {
            try
            {
                var p = await _context.Products.Where(x => x.CompanyIndex == CompanyIndex).ToListAsync();
                var sc = await _context.ShoppingCarts.Where(x => x.CompanyIndex == CompanyIndex).ToListAsync();
                var un = await _context.UnitProducts.ToListAsync();
                if (p.Any() && sc.Any() && un.Any())
                {
                    decimal TotalAmount = 0;
                    foreach (var item in sc)
                    {
                        var rs = p.FirstOrDefault(x => x.ID == item.ProductID);
                        var result = un.FirstOrDefault(x => x.ProductID == item.ProductID);
                        if (rs == null || result == null) return 0;
                        if (item.IsUnit == Data.Enum.IsUnit.Barrel)
                        {
                            TotalAmount = TotalAmount + (result.NumberInBarrel * rs.Price * item.Quantily);
                        }
                        else
                        {
                            TotalAmount = TotalAmount + (rs.Price * item.Quantily);
                        }
                    }
                    return TotalAmount;
                }
                return 0;

            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public async Task<int> CountShoppingCrad(int CompanyIndex)
        {
            try
            {
                var data = await _context.ShoppingCarts.Where(x => x.CompanyIndex == CompanyIndex).ToListAsync();
                if (data == null) return 0;

                return data.Count;
            }
            catch
            {
                return 0;
            }
        }

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
                        ID = 0,
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
            catch(Exception ex)
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
        public async Task<GetShoppingCardViewModel<GetShoppingCartViewModel>> GetListToShoppingCart( int CompanyIndex)
        {
            try
            {
                var query = await (
                                     from i in _context.ShoppingCarts
                                     join p in _context.Products
                                     on i.ProductID equals p.ID
                                     join u in _context.UnitProducts
                                     on i.ProductID equals u.ProductID
                                     where i.CompanyIndex == CompanyIndex
                                     select new
                                     {
                                         p.ID,
                                         p.Name,
                                         i.Quantily,
                                         i.IsUnit,
                                         i.DateCreate,
                                         i.UpdateUser,
                                         TotalAmountProduct = i.IsUnit == Data.Enum.IsUnit.Barrel ? (i.Quantily * u.NumberInBarrel) * p.Price : p.Price * i.Quantily
                                     }).ToListAsync();

                var data = query.Select(x => new GetShoppingCartViewModel()
                    {
                        ProductID = x.ID,
                        ProductName = x.Name,
                        DateCreate = x.DateCreate,
                        Quantily = x.Quantily,
                        IsUnit = x.IsUnit,
                        UpdateUser = x.UpdateUser,
                        TotalAmountProduct = x.TotalAmountProduct
                    }).ToList();

                var total = await TotalAmountToShoppingCard(CompanyIndex);



                var pagedResult = new GetShoppingCardViewModel<GetShoppingCartViewModel>()
                {
                    Items = data,
                    TotalAmount = total
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
