using G9L.Aplication.Catalog.Import;
using G9L.BackEndAPI.Common;
using G9L.Data.ViewModel.Catalog.Import;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace G9L.BackEndAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImportController : ApiControllerBase
    {
        private readonly IImportSevice _importSevice;
        public ImportController(IImportSevice importSevice) : base()
        {
            _importSevice = importSevice;
        }
        //Create
        [HttpPost("CreateToImport")]                                                                   
        public async Task<JsonResult> CreateToImport(int ProviderID)
        {
            var data = await _importSevice.CreateToImport(ProviderID, _CurrentCompanyIndex, _CurrentUpdateUser);
            return Json(data);
        }
        [HttpPost("CreateToImportDetails")]
        public async Task<JsonResult> CreateToImportDetails([FromForm] GetCreateImportDetailsRequest request)
        {
            var data = await _importSevice.CreateToImportDetails(request, _CurrentCompanyIndex, _CurrentUpdateUser);
            return Json(data);
        }
        //Update
        [HttpPost("UpdateImportDetailByID")]
        public async Task<JsonResult> UpdateImportDetailByID([FromForm] GetUpdateToImportDetailsRequest request)
        {
            var data = await _importSevice.UpdateImportDetailByID(request, _CurrentCompanyIndex, _CurrentUpdateUser);
            return Json(data);
        }
        //Delete
        [HttpPost("DeleteToImport")]
        public async Task<JsonResult> DeleteToImport(int ImportID)
        {
            var data = await _importSevice.DeleteToImport(ImportID, _CurrentCompanyIndex);
            return Json(data);
        }
        [HttpPost("DeleteToExportDetails")]
        public async Task<JsonResult> DeleteToExportDetails([FromForm] GetDeleteToImportDetails request)
        {
            var data = await _importSevice.DeleteToExportDetails(request, _CurrentCompanyIndex, _CurrentUpdateUser);
            return Json(data);
        }
        //List
        [HttpGet("GetListToImport")]
        public async Task<JsonResult> GetListToImport([FromQuery] GetManagerImportRequest request)
        {
            var data = await _importSevice.GetListToImport(request, _CurrentCompanyIndex);
            return Json(data);
        }
        [HttpGet("GetImportFinalID")]
        public async Task<JsonResult> GetImportFinalID()
        {
            var data = await _importSevice.GetImportFinalID(_CurrentCompanyIndex);
            return Json(data);
        }

        [HttpGet("GetListToImportDetails")]
        public async Task<JsonResult> GetListToImportDetails(int ImportID)
        {
            var data = await _importSevice.GetListToImportDetails(ImportID, _CurrentCompanyIndex);
            return Json(data);
        }
    }
}
