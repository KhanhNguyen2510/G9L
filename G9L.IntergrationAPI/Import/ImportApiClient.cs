using G9L.Common.SystemBase;
using G9L.Data.ViewModel.Catalog.Import;
using G9L.Data.ViewModel.Common;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace G9L.IntergrationAPI.Import
{
    public class ImportApiClient : BaseAPIClient, IImportApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public ImportApiClient(IHttpClientFactory httpClientFactory, IConfiguration configuration) : base(httpClientFactory, configuration)
        {
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<bool> CreateToImport(GetCreateImportRequest request)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[SystemConnection.AppSettings.BaseAddress]);

            var requestContent = new MultipartFormDataContent();

            if (request.ProviderID != null)
                requestContent.Add(new StringContent(request.ProviderID.ToString()), "ProviderID");

            var response = await client.PostAsync($"/api/Import/CreateToImport", requestContent);

            return response.IsSuccessStatusCode;
        }

        public async Task<PagedResult<GetImportViewModel>> GetListToImport(GetManagerImportRequest request)
        {
            var data = await GetAsync<PagedResult<GetImportViewModel>>($"/api/Import/GetListToImport" +
                $"?KeyWord={request.KeyWord}&ProviderID={request.ProviderID}&DateFrom={request.DateFrom}&DateTo={request.DateTo}" +
                $"&PageIndex={request.PageIndex}&PageSize={request.PageSize}");
            return data;
        }

        public async Task<List<GetImportDetailsViewModel>> GetListToImportDetails(int ImportID)
        {
            var data = await GetAsync<List<GetImportDetailsViewModel>>($"/api/Import/GetListToImportDetails?ImportID={ImportID}");
            return data;
        }
    }
}
