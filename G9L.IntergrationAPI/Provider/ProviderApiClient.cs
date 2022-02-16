using G9L.Common.SystemBase;
using G9L.Data.ViewModel.Catalog.Provider;
using G9L.Data.ViewModel.Common;
using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace G9L.IntergrationAPI.Provider
{
    public class ProviderApiClient : BaseAPIClient, IProviderApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public ProviderApiClient(IHttpClientFactory httpClientFactory, IConfiguration configuration) : base(httpClientFactory, configuration)
        {
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<PagedResult<GetManuProviderViewModel>> GetListToProvider(GetManagerProviderRequest request)
        {
            var data = await GetAsync<PagedResult<GetManuProviderViewModel>>($"/api/Provider/GetListToProvider?KeyWord={request.KeyWord}&PageIndex={request.PageIndex}&PageSize={request.PageSize}");
            return data;
        }
        public async Task<bool> CreateToProvider(GetCreateProviderRequest request)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[SystemConnection.AppSettings.BaseAddress]);

            var requestContent = new MultipartFormDataContent();
            
            requestContent.Add(new StringContent(request.ProviderName.ToString()), "ProviderName");

            if(request.NumberPhone != null)
                requestContent.Add(new StringContent(request.NumberPhone.ToString()), "NumberPhone");
            if(request.Address != null)
                requestContent.Add(new StringContent(request.Address.ToString()), "Address");

            var response = await client.PostAsync($"/api/Provider/CreateToProvider", requestContent);

            return response.IsSuccessStatusCode;
        }
        public async Task<bool> UpdateToProvider(GetUpdateProviderRequest request)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[SystemConnection.AppSettings.BaseAddress]);

            var requestContent = new MultipartFormDataContent();

            requestContent.Add(new StringContent(request.ProviderID.ToString()), "ProviderID");
            if(request.ProviderName != null)
                requestContent.Add(new StringContent(request.ProviderName.ToString()), "ProviderName");
            if (request.NumberPhone != null)
                requestContent.Add(new StringContent(request.NumberPhone.ToString()), "NumberPhone");
            if (request.Address != null)
                requestContent.Add(new StringContent(request.Address.ToString()), "Address");

            var response = await client.PostAsync($"/api/Provider/UpdateToProvider", requestContent);

            return response.IsSuccessStatusCode;
        }
    }
}
