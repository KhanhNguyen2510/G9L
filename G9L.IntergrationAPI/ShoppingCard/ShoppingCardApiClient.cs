using G9L.Data.ViewModel.Catalog.ShoppingCart;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Threading.Tasks;

namespace G9L.IntergrationAPI.NewFolder
{
    public class ShoppingCardApiClient : BaseAPIClient, IShoppingCardApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public ShoppingCardApiClient(IHttpClientFactory httpClientFactory, IConfiguration configuration) : base(httpClientFactory, configuration)
        {
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
        }
        public async Task<int> CountShoppingCrad()
        {
            var data = await GetAsync<int>($"/api/ShoppingCart/CountShoppingCrad");
            return data;
        }
        public async Task<GetShoppingCardViewModel<GetShoppingCartViewModel>> GetListToShoppingCart()
        {
            var data = await GetAsync<GetShoppingCardViewModel<GetShoppingCartViewModel>>($"/api/ShoppingCart/GetListToShoppingCart");
            return data;
        }
    }
}
