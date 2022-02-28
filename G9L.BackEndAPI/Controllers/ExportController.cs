using G9L.Aplication.Catalog.Export;
using G9L.BackEndAPI.Common;
using G9L.Data.ViewModel.Catalog.Export;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace G9L.BackEndAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExportController : ApiControllerBase
    {
        private readonly IExportSevice _exportSevice;

        public ExportController(IExportSevice exportSevice) : base()
        {
            _exportSevice = exportSevice;
        }
        //Create
        [HttpPost("AddShoppingCartInExport")]
        public async Task<JsonResult> AddShoppingCartInExport()
        {
            var data = await _exportSevice.AddShoppingCartInExport(_CurrentCompanyIndex, _CurrentUpdateUser);
            return Json(data);
        }
        //Update
       
        //Delete
        [HttpPost("DeleteToExport/{ExportID}")]
        public async Task<JsonResult> DeleteToExport(int ExportID)
        {
            var data = await _exportSevice.DeleteToExport(ExportID, _CurrentCompanyIndex);
            return Json(data);
        }
        [HttpPost("DeleteToExportDetails")]
        public async Task<JsonResult> DeleteToExportDetails([FromForm] GetDeleteToExportDetails request)
        {
            var data = await _exportSevice.DeleteToExportDetails(request, _CurrentCompanyIndex, _CurrentUpdateUser);
            return Json(data);
        }
        //List
        [HttpGet("GetListToExport")]
        public async Task<JsonResult> GetListToExport([FromQuery] GetManagerExportRequest request)
        {
            var data = await _exportSevice.GetListToExport(request, _CurrentCompanyIndex);
            return Json(data);
        }
        [HttpGet("GetListToExportDetails")]
        public async Task<JsonResult> GetListToExportDetails(int ExportID)
        {
            var data = await _exportSevice.GetListToExportDetails(ExportID, _CurrentCompanyIndex);
            return Json(data);
        }
    }
}
