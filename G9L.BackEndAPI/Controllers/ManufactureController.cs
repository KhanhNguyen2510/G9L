using G9L.Aplication.Catalog.Manufacture;
using G9L.BackEndAPI.Common;
using G9L.Data.ViewModel.Catalog.Mannufacture;
using G9L.Data.ViewModel.Mannufacture;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace G9L.BackEndAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManufactureController : ApiControllerBase
    {
        private readonly IManufactureSevice _manufactureSevice;
        public ManufactureController(IManufactureSevice manufactureSevice) : base()
        {
            _manufactureSevice = manufactureSevice;
        }
        //Create
        [HttpPost("CreateToManufacture")]
        public async Task<JsonResult> CreateToManufacture([FromForm]GetCreateManufactureRequest request)
        {
            var data = await _manufactureSevice.CreateToManufacture(request, _CurrentCompanyIndex, _CurrentUpdateUser);
            return Json(data);
        }
        //Update
        [HttpPost("UpdateToManufacture")]
        public async Task<JsonResult> UpdateToManufacture([FromForm]GetUpdateManufactureRequest request)
        {
            var data = await _manufactureSevice.UpdateToManufacture(request, _CurrentCompanyIndex, _CurrentUpdateUser);
            return Json(data);
        }
        //Delete
        [HttpPost("DeleteToManufacture/{ManufactureID}")]
        public async Task<JsonResult> DeleteToManufacture(int ManufactureID)
        {
            var data = await _manufactureSevice.DeleteToManufacture(ManufactureID, _CurrentCompanyIndex);
            return Json(data);
        }
        //List
        [HttpGet("GetListToManufacture")]
        public async Task<JsonResult> GetListToManufacture([FromQuery]GetManagerManufactureRequest request)
        {
            var data = await _manufactureSevice.GetListToManufacture(request, _CurrentCompanyIndex);
            return Json(data);
        }
        [HttpGet("GetToManufacture/{ManufactureID}")]
        public async Task<JsonResult> GetToManufacture(int ManufactureID)
        {
            var data = await _manufactureSevice.GetToManufacture(ManufactureID, _CurrentCompanyIndex);
            return Json(data);
        }
        [HttpGet("GetToManufacturesOnNameAndID")]
        public async Task<JsonResult> GetToManufacturesOnNameAndID()
        {
            var data = await _manufactureSevice.GetToManufacturesOnNameAndID(_CurrentCompanyIndex);
            return Json(data);
        }
    }
}
