using G9L.Aplication.Catalog.Provider;
using G9L.BackEndAPI.Common;
using G9L.Data.ViewModel.Catalog.Provider;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace G9L.BackEndAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProviderController : ApiControllerBase
    {
        private readonly IProviderSevice _providerSevice;

        public ProviderController(IProviderSevice providerSevice) : base()
        {
            _providerSevice = providerSevice;
        }
        //Check 
        //Create
        [HttpPost("CreateToProvider")]
        public async Task<JsonResult> CreateToProvider([FromForm] GetCreateProviderRequest request)
        {
            var data = await _providerSevice.CreateToProvider(request, _CurrentCompanyIndex, _CurrentUpdateUser);
            return Json(data);
        }
        //Update
        [HttpPost("UpdateToProvider")]
        public async Task<JsonResult> UpdateToProvider([FromForm] GetUpdateProviderRequest request)
        {
            var data = await _providerSevice.UpdateToProvider(request, _CurrentCompanyIndex, _CurrentUpdateUser);
            return Json(data);
        }
        //Delete
        [HttpPost("DeleteToProvider/{ProviderID}")]
        public async Task<JsonResult> DeleteToProvider(int ProviderID)
        {
            var data = await _providerSevice.DeleteToProvider(ProviderID, _CurrentCompanyIndex);
            return Json(data);
        }
        //List
        [HttpGet("GetListToProvider")]
        public async Task<JsonResult> GetListToProvider([FromQuery]GetManagerProviderRequest request)
        {
            var data = await _providerSevice.GetListToProvider(request, _CurrentCompanyIndex);
            return Json(data);
        }
        [HttpGet("GetToProvider/{ProviderID}")]
        public async Task<JsonResult> GetToProvider(int ProviderID)
        {
            var data = await _providerSevice.GetToProvider(ProviderID, _CurrentCompanyIndex);
            return Json(data);
        }
    }
}
