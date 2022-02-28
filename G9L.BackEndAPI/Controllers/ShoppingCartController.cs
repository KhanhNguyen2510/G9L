using G9L.Aplication.Catalog.ShoppingCart;
using G9L.BackEndAPI.Common;
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

        //Create
        [HttpPost("CreateOrUpdateToShoppingCart")]
        public async Task<JsonResult> CreateOrUpdateToShoppingCart([FromForm]GetCreateToShoppingCartRequest  request)
        {
            var data = await _shoppingCartSevice.CreateOrUpdateToShoppingCart(request , _CurrentCompanyIndex, _CurrentUpdateUser);
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
        public async Task<JsonResult> DeleteToShoppingCart([FromForm] PagingRequestBase request)
        {
            var data = await _shoppingCartSevice.GetListToShoppingCart(request, _CurrentCompanyIndex);
            return Json(data);
        }
    }
}
