using G9L.Data.ViewModel.Catalog.ShoppingCart;
using System.Threading.Tasks;

namespace G9L.Aplication.Catalog.ShoppingCart
{
    public interface IShoppingCartSevice
    {
        //Check

        //Count
        Task<int> CountShoppingCrad(int CompanyIndex);

        //Create

        Task<bool> CreateOrUpdateToShoppingCart(GetCreateToShoppingCartRequest request, int CompanyIndex, string UpdateUser);

        //Update

        //Delete
        Task<bool> DeleteToShoppingCart(int ProductID, int CompanyIndex);
        Task<bool> DeleteAllToShoppingCart(int CompanyIndex);
        //List
        Task<GetShoppingCardViewModel<GetShoppingCartViewModel>> GetListToShoppingCart(int CompanyIndex);
    }
}
