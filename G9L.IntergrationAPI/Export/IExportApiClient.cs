using G9L.Data.ViewModel.Catalog.Export;
using G9L.Data.ViewModel.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace G9L.IntergrationAPI.Export
{
    public interface IExportApiClient
    {
        Task<PagedResult<GetExportViewModel>> GetListToExport(GetManagerExportRequest request);
        Task<List<GetExportDetailsViewModel>> GetListToExportDetails(int ExportID);
    }
}
