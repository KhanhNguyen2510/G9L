using G9L.Data.ViewModel.Catalog.Import;
using G9L.Data.ViewModel.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace G9L.Aplication.Catalog.Import
{
    public interface IImportSevice
    {
        //Check
        //Create
        Task<bool> CreateToImport(int? ProviderID, int CompanyIndex, string UpdateUser);
        Task<bool> CreateToImportDetails(GetCreateImportDetailsRequest request, int CompanyIndex, string UpdateUser);
        //Update
        Task<bool> UpdateImportDetailByID(GetUpdateToImportDetailsRequest request, int CompanyIndex, string UpdateUser);
        //Delete
        Task<bool> DeleteToImport(int ImportID, int CompanyIndex);
        Task<bool> DeleteToExportDetails(GetDeleteToImportDetails request, int CompanyIndex, string UpdateUser);
        //List
        Task<PagedResult<GetImportViewModel>> GetListToImport(GetManagerImportRequest request, int CompanyIndex);
        Task<List<GetImportDetailsViewModel>> GetListToImportDetails(int ImportID, int CompanyIndex);
        Task<GetImportFinal> GetImportFinalID(int CompanyIndex);
        Task<GetImportAndImportDetailsViewModel<GetImportDetailsVM>> GetListImportAndImportDetails(int ImportID, int CompanyIndex);
    }
}
