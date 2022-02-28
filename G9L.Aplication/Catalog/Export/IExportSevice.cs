using G9L.Data.ViewModel.Catalog.Export;
using G9L.Data.ViewModel.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace G9L.Aplication.Catalog.Export
{
    public interface IExportSevice
    {
        //Check
        //Create
        Task<int> AddShoppingCartInExport(int CompanyIndex, string UpdateUser);
        //Update

        //Delete
        Task<bool> DeleteToExport(int ExportID, int CompanyIndex);
        Task<bool> DeleteToExportDetails(GetDeleteToExportDetails request, int CompanyIndex, string UpdateUser);
        //List
        Task<PagedResult<GetExportViewModel>> GetListToExport(GetManagerExportRequest request, int CompanyIndex);
        Task<List<GetExportDetailsViewModel>> GetListToExportDetails(int ExportID, int CompanyIndex);
    }
}
