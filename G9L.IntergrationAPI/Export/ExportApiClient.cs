using G9L.Data.ViewModel.Catalog.Export;
using G9L.Data.ViewModel.Common;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace G9L.IntergrationAPI.Export
{
    class ExportApiClient : BaseAPIClient, IExportApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public ExportApiClient(IHttpClientFactory httpClientFactory, IConfiguration configuration) : base(httpClientFactory, configuration)
        {
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<PagedResult<GetExportViewModel>> GetListToExport(GetManagerExportRequest request)
        {
            var data = await GetAsync<PagedResult<GetExportViewModel>>($"/api/Export/GetListToExport" +
                $"?KeyWord={request.KeyWord}&DateFrom={request.DateFrom}&DateTo={request.DateTo}&IsExport={request.IsExport}" +
                $"&PageIndex={request.PageIndex}&PageSize={request.PageSize}");
            return data;
        }

        public async Task<List<GetExportDetailsViewModel>> GetListToExportDetails(int ExportID)
        {
            var data = await GetAsync<List<GetExportDetailsViewModel>>($"/api/Export/GetListToExportDetails?ExportID={ExportID}");
            return data;
        }
    }
}