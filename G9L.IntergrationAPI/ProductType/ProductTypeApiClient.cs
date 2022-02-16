using G9L.Common.SystemBase;
using G9L.Data.ViewModel.Catalog.ProductType;
using G9L.Data.ViewModel.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace G9L.IntergrationAPI.ProductType
{
    public class ProductTypeApiClient : BaseAPIClient, IProductTypeApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public ProductTypeApiClient(IHttpClientFactory httpClientFactory, IConfiguration configuration) : base(httpClientFactory, configuration)
        {
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
        }
        public async Task<PagedResult<GetProductTypeViewModel>> GetListToProductType(GetManagerProductTypeRequest request)
        {
            var data = await GetAsync<PagedResult<GetProductTypeViewModel>>($"/api/ProductType/GetListToProductType?KeyWord={request.KeyWord}&PageIndex={request.PageIndex}&PageSize={request.PageSize}");
            return data;
        }
        public async Task<List<GetProducType>> GetToProducTypeOnNameAndID()
        {
            var data = await GetAsync<List<GetProducType>>($"/api/ProductType/GetToProducTypeOnNameAndID");
            return data;
        }
        public async Task<bool> CreateToProductType(GetCreateProductTypeRequest request, IFormFile formFile)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[SystemConnection.AppSettings.BaseAddress]);

            var requestContent = new MultipartFormDataContent();

            requestContent.Add(new StringContent(request.Name.ToString()), "Name");
            requestContent.Add(new StringContent(request.Image.ToString()), "Image");
            requestContent.Add(new StringContent(formFile.ToString()), "formFile");

            var response = await client.PostAsync($"/api/ProductType/CreateToProductTyper", requestContent);

            return response.IsSuccessStatusCode;
        }
        public async Task<bool> UpdateToProductType(GetUpdateProductTypeRequest request)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[SystemConnection.AppSettings.BaseAddress]);

            var requestContent = new MultipartFormDataContent();

            requestContent.Add(new StringContent(request.ProcductTypeID.ToString()), "ProcductTypeID");
            requestContent.Add(new StringContent(request.ProcductTypeName.ToString()), "ProcductTypeName");
            requestContent.Add(new StringContent(request.Image.ToString()), "Image");

            var response = await client.PostAsync($"/api/ProductType/UpdateToProductType", requestContent);

            return response.IsSuccessStatusCode;
        }
    }
}
