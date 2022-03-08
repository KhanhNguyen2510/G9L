using G9L.Data.ViewModel.Catalog.ShoppingCart;
using System.Threading.Tasks;

namespace G9L.IntergrationAPI.NewFolder
{
    public interface IShoppingCardApiClient
    {
        Task<int> CountShoppingCrad();
        Task<GetShoppingCardViewModel<GetShoppingCartViewModel>> GetListToShoppingCart();
    }
}
