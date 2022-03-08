using G9L.Data.Enum;
using G9L.Data.ViewModel.Catalog.Product;
using G9L.IntergrationAPI.Manufacture;
using G9L.IntergrationAPI.NewFolder;
using G9L.IntergrationAPI.Product;
using G9L.IntergrationAPI.ProductType;
using G9L.Wedsite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Threading.Tasks;

namespace G9L.Wedsite.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductApiClient _productApiClient;
        private readonly IProductTypeApiClient _productTypeApiClient;
        private readonly IManufactureApiClient _manufactureApiClinet;
        private readonly IShoppingCardApiClient _shoppingCardApiClient;
        public ProductController(IProductApiClient productApiClient, IShoppingCardApiClient shoppingCardApiClient , IProductTypeApiClient productTypeApiClient, IManufactureApiClient manufactureApiClient)
        {
            _manufactureApiClinet = manufactureApiClient;
            _productTypeApiClient = productTypeApiClient;
            _productApiClient = productApiClient;
            _shoppingCardApiClient = shoppingCardApiClient;
        }

        public class GetUnitProduct
        {
            public IsUnit ID { get; set; }
            public string Name { get; set; }
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

            var st = await _productApiClient.GetToProductToName();
            var pt = await _productTypeApiClient.GetToProducTypeOnNameAndID();
            var m = await _manufactureApiClinet.GetToManufacturesOnNameAndID();

            ViewBag.ProductType = pt.Select(x => new SelectListItem()
            {
                Text = x.ProducTypeName,
                Value = x.ProducTypeID.ToString(),
                Selected = ProductTypeID == x.ProducTypeID
            });

            ViewBag.Manufactures = m.Select(x => new SelectListItem()
            {
                Text = x.ManufactureName,
                Value = x.ManufactureID.ToString(),
                Selected = ManufactureID == x.ManufactureID
            });

           
            ViewBag.Product = st.Select(x => new SelectListItem()
            {
                Text = x.ProductName,
                Value = x.ProductName,
                Selected = StorageLocations == x.ProductName
            });

            if (TempData["Success"] != null)
            {
                ViewBag.SuccessMessage = TempData["Success"];
            }
            if (TempData["Error"] != null)
            {
                ViewBag.ErrorMessage = TempData["Error"];
            }

            var data = await _productApiClient.GetListToProduct(request);

            return View(data);
        }

        public async Task<IActionResult> IndexProduct(string KeyWord, int? ManufactureID, int? ProductTypeID, string StorageLocations, int PageIndex = 1, int PageSize = 1000)
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
            ViewBag.KeyWord = KeyWord;

            var sc = await _shoppingCardApiClient.CountShoppingCrad();

            var st = await _productApiClient.GetToProductToName();
            var pt = await _productTypeApiClient.GetToProducTypeOnNameAndID();
            var m = await _manufactureApiClinet.GetToManufacturesOnNameAndID();

            ViewBag.ShoppingCard = sc;

            ViewBag.ProductType = pt.Select(x => new SelectListItem()
            {
                Text = x.ProducTypeName,
                Value = x.ProducTypeID.ToString(),
                Selected = ProductTypeID == x.ProducTypeID
            });

            ViewBag.Manufactures = m.Select(x => new SelectListItem()
            {
                Text = x.ManufactureName,
                Value = x.ManufactureID.ToString(),
                Selected = ManufactureID == x.ManufactureID
            });


            ViewBag.Product = st.Select(x => new SelectListItem()
            {
                Text = x.ProductName,
                Value = x.ProductName,
                Selected = StorageLocations == x.ProductName
            });

            if (TempData["Success"] != null)
            {
                ViewBag.SuccessMessage = TempData["Success"];
            }
            if (TempData["Error"] != null)
            {
                ViewBag.ErrorMessage = TempData["Error"];
            }

            var data = await _productApiClient.GetListToProduct(request);

            return View(data);
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Create([FromForm] GetCreateProductRequest request)
        {
            var result = await _productApiClient.CreateToProduct(request);

            if (result == true)
            {
                TempData["Success"] = MessageModel.AddItemSuccessful();
            }
            else
            {
                TempData["Error"] = MessageModel.AddItemFaled();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Update([FromForm] GetUpdateProductRequest request)
        {

            var result = await _productApiClient.UpdateToProduct(request);

            if (result == true)
            {
                TempData["Success"] = MessageModel.UpdateItemSuccessful();
            }
            else
            {
                TempData["Error"] = MessageModel.UpdateItemFaled();
            }
            return RedirectToAction("Index");
        }
    }
}
