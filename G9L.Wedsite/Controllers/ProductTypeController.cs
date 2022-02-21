using G9L.Data.ViewModel.Catalog.ProductType;
using G9L.IntergrationAPI.ProductType;
using G9L.Wedsite.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace G9L.Wedsite.Controllers
{
    public class ProductTypeController : Controller
    {
        private readonly IProductTypeApiClient _productTypeApiClient;
        public ProductTypeController(IProductTypeApiClient productTypeApiClient)
        {
            _productTypeApiClient = productTypeApiClient;
        }

        public async Task<IActionResult> Index(string KeyWord, int PageIndex = 1, int PageSize = 1)
        {
            var request = new GetManagerProductTypeRequest()
            {
                KeyWord = KeyWord,
                PageIndex = PageIndex,
                PageSize = PageSize
            };

            var data = await _productTypeApiClient.GetListToProductType(request);


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
        public async Task<IActionResult> Table(string KeyWord, int PageIndex = 1, int PageSize = 100000)
        {
            var request = new GetManagerProductTypeRequest()
            {
                KeyWord = KeyWord,
                PageIndex = PageIndex,
                PageSize = PageSize
            };
            var data = await _productTypeApiClient.GetListToProductType(request);

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

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Create([FromForm] GetCreateProductTypeRequest request)
        {
            var result = await _productTypeApiClient.CreateToProductType(request);
            if (result == true)
            {
                TempData["Success"] = MessageModel.AddItemSuccessful();
            }
            else
            {
                TempData["Error"] = MessageModel.AddItemFaled();
            }
            return RedirectToAction("Table");
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Update([FromForm] GetUpdateProductTypeRequest request)
        { 

            var result = await _productTypeApiClient.UpdateToProductType(request);
            if (result == true)
            {
                TempData["Success"] = MessageModel.UpdateItemSuccessful();
            }
            else
            {
                TempData["Error"] = MessageModel.UpdateItemFaled();
            }
            return RedirectToAction("Table");
        }
    }
}
