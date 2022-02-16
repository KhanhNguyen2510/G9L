using G9L.Common.SystemBase;
using G9L.Data.ViewModel.Catalog.Mannufacture;
using G9L.Data.ViewModel.Common;
using G9L.Data.ViewModel.Mannufacture;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace G9L.IntergrationAPI.Manufacture
{
    public class ManufactureApiClient : BaseAPIClient, IManufactureApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public ManufactureApiClient(IHttpClientFactory httpClientFactory, IConfiguration configuration) : base(httpClientFactory, configuration)
        {
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<PagedResult<GetManufactureViewModel>> GetListToManufacture(GetManagerManufactureRequest request)
        {
            var data = await GetAsync<PagedResult<GetManufactureViewModel>>($"/api/Manufacture/GetListToManufacture?KeyWord={request.KeyWord}&PageIndex={request.PageIndex}&PageSize={request.PageSize}");
            return data;
        }
        public async Task<List<GetManufacture>> GetToManufacturesOnNameAndID()
        {
            var data = await GetAsync<List<GetManufacture>>($"/api/Manufacture/GetToManufacturesOnNameAndID");
            return data;
        }
        public async Task<bool> CreateToManufacture(GetCreateManufactureRequest request)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[SystemConnection.AppSettings.BaseAddress]);

            var requestContent = new MultipartFormDataContent();

            requestContent.Add(new StringContent(request.Name.ToString()), "Name");
            requestContent.Add(new StringContent(request.Local.ToString()), "Local");

            var response = await client.PostAsync($"/api/Manufacture/CreateToManufacture", requestContent);

            return response.IsSuccessStatusCode;
        }
        public async Task<bool> UpdateToManufacture(GetUpdateManufactureRequest request)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[SystemConnection.AppSettings.BaseAddress]);

            var requestContent = new MultipartFormDataContent();

            requestContent.Add(new StringContent(request.ManufactureID.ToString()), "ManufactureID");
            requestContent.Add(new StringContent(request.ManufactureName.ToString()), "ManufactureName");
            requestContent.Add(new StringContent(request.Local.ToString()), "Local");

            var response = await client.PostAsync($"/api/Manufacture/UpdateToManufacture", requestContent);

            return response.IsSuccessStatusCode;
        }
    }
}
