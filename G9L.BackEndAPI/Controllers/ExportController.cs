using G9L.Aplication.Catalog.Export;
using G9L.BackEndAPI.Common;
using G9L.Data.ViewModel.Catalog.Export;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace G9L.BackEndAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExportController : ApiControllerBase
    {
        private readonly IExportSevice _exportSevice;

        public ExportController(IServiceProvider pserviceProvider) : base(pserviceProvider)
        {
            _exportSevice = TryResolve<IExportSevice>();
        }
        //Create
        [HttpPost("CreateToExport")]
        public async Task<JsonResult> CreateToExport()
        {
            var data = await _exportSevice.CreateToExport(_CurrentCompanyIndex, _CurrentUpdateUser);
            return Json(data);
        }
        [HttpPost("CreateToExportDetails")]
        public async Task<JsonResult> CreateToExportDetails([FromForm] GetCreateExportDetailsRequest request)
        {
            var data = await _exportSevice.CreateToExportDetails(request, _CurrentCompanyIndex, _CurrentUpdateUser);
            return Json(data);
        }
        //Update
        [HttpPost("UpdateToExportByExportDetails")]
        public async Task<JsonResult> UpdateToExportByExportDetails(int ExportID)
        {
            var data = await _exportSevice.UpdateToExportByExportDetails(ExportID, _CurrentCompanyIndex, _CurrentUpdateUser);
            return Json(data);
        }
        [HttpPost("UpdateToExport")]
        public async Task<JsonResult> UpdateToExport([FromForm] GetUpdateExportRequest request)
        {
            var data = await _exportSevice.UpdateToExport(request, _CurrentCompanyIndex, _CurrentUpdateUser);
            return Json(data);
        }
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
