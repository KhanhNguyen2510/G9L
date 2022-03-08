using G9L.Data.ViewModel.Common;
using G9L.IntergrationAPI.NewFolder;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace G9L.Wedsite.Controllers
{
    public class ShoppingCardController : Controller
    {
        private readonly IShoppingCardApiClient _shoppingCardApiClient;
        public ShoppingCardController(IShoppingCardApiClient shoppingCardApiClient)
        {
            _shoppingCardApiClient = shoppingCardApiClient;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _shoppingCardApiClient.GetListToShoppingCart();

            if (TempData["Success"] != null)
            {
                ViewBag.SuccessMessage = TempData["Success"];
            }
            if (TempData["Error"] != null)
            {
                ViewBag.ErrorMessage = TempData["Error"];
            }
            return View(data);
        }
    }
}
