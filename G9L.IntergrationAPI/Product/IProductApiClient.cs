using G9L.Data.ViewModel.Catalog.Product;
using G9L.Data.ViewModel.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace G9L.IntergrationAPI.Product
{
    public interface IProductApiClient
    {
        Task<PagedResult<GetManagerProductViewModel>> GetListToProduct(GetManagerProductRequest request);
        Task<bool> CreateToProduct(GetCreateProductRequest request);
        Task<bool> UpdateToProduct(GetUpdateProductRequest request);
        Task<List<GetProduct>> GetToProductToNameAndID();
        Task<List<GetProductByName>> GetToProductToName();
    }
}
