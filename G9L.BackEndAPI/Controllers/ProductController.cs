using G9L.Aplication.Catalog.Product;
using G9L.BackEndAPI.Common;
using G9L.Data.ViewModel.Catalog.Product;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace G9L.BackEndAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ApiControllerBase
    {
        private readonly IProductSevice _productSevice;
        public ProductController(IProductSevice productSevice) : base()
        {
            _productSevice = productSevice;
        }

        //Create
        [HttpPost("CreateToProduct")]
        public async Task<JsonResult> CreateToProduct([FromForm]GetCreateProductRequest request)
        {
            var data = await _productSevice.CreateToProduct(request, _CurrentCompanyIndex, _CurrentUpdateUser);
            return Json(data);
        }
        //Update
        [HttpPost("UpdateToProduct")]
        public async Task<JsonResult> UpdateToProduct([FromForm]GetUpdateProductRequest request)
        {
            var data = await _productSevice.UpdateToProduct(request, _CurrentCompanyIndex, _CurrentUpdateUser);
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
        [HttpGet("GetToProduct/{ProductID}")]
        public async Task<JsonResult> GetToProduct(int ProductID)
        {
            var data = await _productSevice.GetToProduct(ProductID, _CurrentCompanyIndex);
            return Json(data);
        }
        [HttpGet("GetToProductToNameAndID")]
        public async Task<JsonResult> GetToProductToNameAndID()
        {
            var data = await _productSevice.GetToProductToNameAndID(_CurrentCompanyIndex);
            return Json(data);
        }
        [HttpGet("GetToProductToName")]
        public async Task<JsonResult> GetToProductToName()
        {
            var data = await _productSevice.GetToProductToName(_CurrentCompanyIndex);
            return Json(data);
        }

    }
}
