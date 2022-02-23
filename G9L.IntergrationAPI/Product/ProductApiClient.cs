using G9L.Common.SystemBase;
using G9L.Data.ViewModel.Catalog.Product;
using G9L.Data.ViewModel.Common;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
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
        public async Task<List<GetProduct>> GetToProductToNameAndID()
        {
            var data = await GetAsync<List<GetProduct>>($"/api/Product/GetToProductToNameAndID");
            return data;
        }
        public async Task<List<GetProductByName>> GetToProductToName()
        {
            var data = await GetAsync<List<GetProductByName>>($"/api/Product/GetToProductToName");
            return data;
        }
        public async Task<bool> CreateToProduct(GetCreateProductRequest request)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[SystemConnection.AppSettings.BaseAddress]);

            var requestContent = new MultipartFormDataContent();

            requestContent.Add(new StringContent(request.ProductName.ToString()), "ProductName");
            requestContent.Add(new StringContent(request.Price.ToString()), "Price");
            requestContent.Add(new StringContent(request.ProductTypeID.ToString()), "ProductTypeID");
            requestContent.Add(new StringContent(request.ManufactureID.ToString()), "ManufactureID");
            requestContent.Add(new StringContent(request.IsUnit.ToString()), "IsUnit");
            if (request.StorageLocations != null)
                requestContent.Add(new StringContent(request.StorageLocations.ToString()), "StorageLocations");
            if (request.Quantily != null)
                requestContent.Add(new StringContent(request.Quantily.ToString()), "Quantily");
            if (request.Image1 != null)
                requestContent.Add(new StringContent(request.Image1.ToString()), "Image1");
            if (request.Image2 != null)
                requestContent.Add(new StringContent(request.Image2.ToString()), "Image2");
            if (request.Image3 != null)
                requestContent.Add(new StringContent(request.Image3.ToString()), "Image3");
            if (request.Description != null)
                requestContent.Add(new StringContent(request.Description.ToString()), "Description");
             if(request.NumberInBarrel != null)
                requestContent.Add(new StringContent(request.NumberInBarrel.ToString()), "NumberInBarrel");

            var response = await client.PostAsync($"/api/Product/CreateToProduct", requestContent);

            return response.IsSuccessStatusCode;
        }
        public async Task<bool> UpdateToProduct(GetUpdateProductRequest request)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[SystemConnection.AppSettings.BaseAddress]);

            var requestContent = new MultipartFormDataContent();

            requestContent.Add(new StringContent(request.ProductID.ToString()), "ProductID");
            if (request.StorageLocations != null)
                requestContent.Add(new StringContent(request.StorageLocations.ToString()), "StorageLocations");
            if (request.Quantily != null)
                requestContent.Add(new StringContent(request.Quantily.ToString()), "Quantily");
            if (request.Image1 != null)
                requestContent.Add(new StringContent(request.Image1.ToString()), "Image1");
            if (request.Image2 != null)
                requestContent.Add(new StringContent(request.Image2.ToString()), "Image2");
            if (request.Image3 != null)
                requestContent.Add(new StringContent(request.Image3.ToString()), "Image3");
            if (request.ManufactureID != null)
                requestContent.Add(new StringContent(request.ManufactureID.ToString()), "ManufactureID");
            if (request.Description != null)
                requestContent.Add(new StringContent(request.Description.ToString()), "Description");
            if (request.ProductName != null)
                requestContent.Add(new StringContent(request.ProductName.ToString()), "ProductName");
            if (request.Price != null)
                requestContent.Add(new StringContent(request.Price.ToString()), "Price");
            if (request.ProductTypeID != null)
                requestContent.Add(new StringContent(request.ProductTypeID.ToString()), "ProductTypeID");

            var response = await client.PostAsync($"/api/Product/UpdateToProduct", requestContent);

            return response.IsSuccessStatusCode;
        }
    }
}
