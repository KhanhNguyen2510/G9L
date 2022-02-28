using G9L.Data.ViewModel.Catalog.Import;
using G9L.Data.ViewModel.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace G9L.IntergrationAPI.Import
{
    public interface IImportApiClient
    {
        Task<PagedResult<GetImportViewModel>> GetListToImport(GetManagerImportRequest request);
        Task<List<GetImportDetailsViewModel>> GetListToImportDetails(int ImportID);
        Task<bool> CreateToImportDetails(GetCreateImportDetailsRequest request);
        Task<bool> DeleteToImport(int ImportID);
        Task<GetImportAndImportDetailsViewModel<GetImportDetailsVM>> GetListImportAndImportDetails(int ImportID);
    }
}
