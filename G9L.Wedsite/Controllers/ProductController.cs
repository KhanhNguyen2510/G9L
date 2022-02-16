using G9L.Data.ViewModel.Catalog.Product;
using G9L.IntergrationAPI.Product;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace G9L.Wedsite.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductApiClient _productApiClient;
        public ProductController(IProductApiClient productApiClient)
        {
            _productApiClient = productApiClient;
        }
        public async Task<IActionResult> Index(string KeyWord, int? ManufactureID ,int? ProductTypeID,string StorageLocations, int PageIndex = 1, int PageSize = 1000)
        {
            var request = new GetManagerProductRequest()
            {
                KeyWord = KeyWord,
                ManufactureID = ManufactureID,
                ProductTypeID = ProductTypeID,
                StorageLocations = StorageLocations,
                PageIndex = PageIndex,
                PageSize = PageSize
            };

            var data = await _productApiClient.GetListToProduct(request);

            if (TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];

            }
            if (TempData["resultError"] != null)
            {
                ViewBag.SuccessMsgErro = TempData["resultError"];
            }
            return View(data);
        }
    }
}
