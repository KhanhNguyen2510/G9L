using G9L.Aplication.Catalog.Product;
using G9L.BackEndAPI.Common;
using G9L.Data.ViewModel.Catalog.Product;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace G9L.BackEndAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ApiControllerBase
    {
        private readonly IProductSevice _productSevice;
        public ProductController(IServiceProvider pserviceProvider) : base(pserviceProvider)
        {
            _productSevice = TryResolve<IProductSevice>();
        }

        //Create
        [HttpPost("CreateToProvider")]
        public async Task<JsonResult> CreateToProvider([FromForm]GetCreateProductRequest request)
        {
            var data = await _productSevice.CreateToProvider(request, _CurrentCompanyIndex, _CurrentUpdateUser);
            return Json(data);
        }
        //Update
        [HttpPost("UpdateToProvider")]
        public async Task<JsonResult> UpdateToProvider([FromForm]GetUpdateProductRequest request)
        {
            var data = await _productSevice.UpdateToProvider(request, _CurrentCompanyIndex, _CurrentUpdateUser);
            return Json(data);
        }
        //Delete
        [HttpPost("DeleteToProduct/{ProductID}")]
        public async Task<JsonResult> DeleteToProduct(int ProductID)
        {
            var data = await _productSevice.DeleteToProduct(ProductID, _CurrentCompanyIndex);
            return Json(data);
        }
        //List
        [HttpGet("GetListToProduct")]
        public async Task<JsonResult> GetListToProduct([FromQuery]GetManagerProductRequest request)
        {
            var data = await _productSevice.GetListToProduct(request, _CurrentCompanyIndex);
            return Json(data);
        }

    }
}
