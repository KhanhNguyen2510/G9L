using G9L.Data.ViewModel.Catalog.ProductType;
using G9L.Data.ViewModel.Common;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace G9L.IntergrationAPI.ProductType
{
    public interface IProductTypeApiClient
    {
        Task<PagedResult<GetProductTypeViewModel>> GetListToProductType(GetManagerProductTypeRequest request);
        Task<bool> CreateToProductType(GetCreateProductTypeRequest request, IFormFile formFile);
        Task<bool> UpdateToProductType(GetUpdateProductTypeRequest request);
        Task<List<GetProducType>> GetToProducTypeOnNameAndID();
    }
}
