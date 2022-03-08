using G9L.Aplication.Catalog.ShoppingCart;
using G9L.BackEndAPI.Common;
using G9L.Data.Enum;
using G9L.Data.ViewModel.Catalog.ShoppingCart;
using G9L.Data.ViewModel.Common;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace G9L.BackEndAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : ApiControllerBase
    {
        private readonly IShoppingCartSevice _shoppingCartSevice;
        public ShoppingCartController(IShoppingCartSevice shoppingCartSevice) : base()
        {
            _shoppingCartSevice = shoppingCartSevice;
        }
        //Check

        //Count 
        [HttpGet("CountShoppingCrad")]
        public async Task<JsonResult> CountShoppingCrad()
        {
            var data = await _shoppingCartSevice.CountShoppingCrad(_CurrentCompanyIndex);
            return Json(data);
        }

        //Create
        [HttpPost("CreateOrUpdateToShoppingCart/{ProductID}")]
        public async Task<JsonResult> CreateOrUpdateToShoppingCart(int ProductID, int? Quantily, IsUnit? IsUnit)
        {
            var result = new GetCreateToShoppingCartRequest()
            {
                ProductID = ProductID,
                Quantily = Quantily,
                IsUnit = IsUnit
            };
            var data = await _shoppingCartSevice.CreateOrUpdateToShoppingCart(result, _CurrentCompanyIndex, _CurrentUpdateUser);
            return Json(data);
        }
        //Update

        //Delete
        [HttpPost("DeleteAllToShoppingCart")]
        public async Task<JsonResult> DeleteAllToShoppingCart()
        {
            var data = await _shoppingCartSevice.DeleteAllToShoppingCart( _CurrentCompanyIndex);
            return Json(data);
        }
        [HttpPost("DeleteToShoppingCart/{ProductID}")]
        public async Task<JsonResult> DeleteToShoppingCart(int ProductID)
        {
            var data = await _shoppingCartSevice.DeleteToShoppingCart( ProductID,_CurrentCompanyIndex);
            return Json(data);
        }
        //List
        [HttpGet("GetListToShoppingCart")]
        public async Task<JsonResult> GetListToShoppingCart()
        {
            var data = await _shoppingCartSevice.GetListToShoppingCart(_CurrentCompanyIndex);
            return Json(data);
        }
    }
}
