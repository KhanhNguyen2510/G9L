using G9L.Common.SystemBase;
using G9L.Data.ViewModel.Catalog.Product;
using G9L.Data.ViewModel.Common;
using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace G9L.IntergrationAPI.Product
{
    public class ProductApiClient : BaseAPIClient, IProductApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public ProductApiClient(IHttpClientFactory httpClientFactory, IConfiguration configuration) : base(httpClientFactory, configuration)
        {
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<PagedResult<GetManagerProductViewModel>> GetListToProduct(GetManagerProductRequest request)
        {
            var data = await GetAsync<PagedResult<GetManagerProductViewModel>>($"/api/Product/GetListToProduct" +
                $"?KeyWord={request.KeyWord}&ManufactureID={request.ManufactureID}" +
                $"&ProductTypeID={request.ProductTypeID}&StorageLocations={request.StorageLocations}" +
                $"&PageIndex={request.PageIndex}&PageSize={request.PageSize}");
            return data;
        }
        public async Task<bool> CreateToProduct(GetCreateProductRequest request)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[SystemConnection.AppSettings.BaseAddress]);

            var requestContent = new MultipartFormDataContent();

            requestContent.Add(new StringContent(request.StorageLocations.ToString()), "StorageLocations");
            requestContent.Add(new StringContent(request.ProductTypeID.ToString()), "ProductTypeID");
            requestContent.Add(new StringContent(request.Price.ToString()), "Price");
            requestContent.Add(new StringContent(request.Quantily.ToString()), "Quantily");
            requestContent.Add(new StringContent(request.Image1.ToString()), "Image1");
            requestContent.Add(new StringContent(request.Image2.ToString()), "Image2");
            requestContent.Add(new StringContent(request.Image3.ToString()), "Image3");
            requestContent.Add(new StringContent(request.ProductName.ToString()), "ProductName");
            requestContent.Add(new StringContent(request.ManufactureID.ToString()), "ManufactureID");
            requestContent.Add(new StringContent(request.Description.ToString()), "Description");

            var response = await client.PostAsync($"/api/Product/CreateToProduct", requestContent);

            return response.IsSuccessStatusCode;
        }
        public async Task<bool> UpdateToProduct(GetUpdateProductRequest request)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[SystemConnection.AppSettings.BaseAddress]);

            var requestContent = new MultipartFormDataContent();

            requestContent.Add(new StringContent(request.StorageLocations.ToString()), "StorageLocations");
            requestContent.Add(new StringContent(request.ProductTypeID.ToString()), "ProductTypeID");
            requestContent.Add(new StringContent(request.Price.ToString()), "Price");
            requestContent.Add(new StringContent(request.ProductID.ToString()), "ProductID");
            requestContent.Add(new StringContent(request.Quantily.ToString()), "Quantily");
            requestContent.Add(new StringContent(request.Image1.ToString()), "Image1");
            requestContent.Add(new StringContent(request.Image2.ToString()), "Image2");
            requestContent.Add(new StringContent(request.Image3.ToString()), "Image3");
            requestContent.Add(new StringContent(request.ProductName.ToString()), "ProductName");
            requestContent.Add(new StringContent(request.ManufactureID.ToString()), "ManufactureID");
            requestContent.Add(new StringContent(request.Description.ToString()), "Description");

            var response = await client.PostAsync($"/api/Product/UpdateToProduct", requestContent);

            return response.IsSuccessStatusCode;
        }
    }
}
