using G9L.Data.ViewModel.Catalog.ShoppingCart;
using G9L.Data.ViewModel.Common;
using System.Threading.Tasks;

namespace G9L.Aplication.Catalog.ShoppingCart
{
   public interface IShoppingCartSevice
    {
        //Check
        //Create

        Task<bool> CreateOrUpdateToShoppingCart(GetCreateToShoppingCartRequest request, int CompanyIndex, string UpdateUser);

        //Update

        //Delete
        Task<bool> DeleteToShoppingCart(int ProductID, int CompanyIndex);
        Task<bool> DeleteAllToShoppingCart(int CompanyIndex);
        //List
        Task<PagedResult<GetShoppingCartViewModel>> GetListToShoppingCart(PagingRequestBase request, int CompanyIndex);
    }
}
