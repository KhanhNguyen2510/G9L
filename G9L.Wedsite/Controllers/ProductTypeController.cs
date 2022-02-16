﻿using G9L.Data.ViewModel.Catalog.ProductType;
using G9L.IntergrationAPI.ProductType;
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


            if (TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];

            }
            if (TempData["resultErro"] != null)
            {
                ViewBag.SuccessMsgErro = TempData["resultErro"];
            }
            return View(data);
        }
        public async Task<IActionResult> Table(string KeyWord, int PageIndex = 1, int PageSize = 1)
        {
            var request = new GetManagerProductTypeRequest()
            {
                KeyWord = KeyWord,
                PageIndex = PageIndex,
                PageSize = PageSize
            };
            var data = await _productTypeApiClient.GetListToProductType(request);


            if (TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];

            }
            if (TempData["resultErro"] != null)
            {
                ViewBag.SuccessMsgErro = TempData["resultErro"];
            }
            return View(data);
        }

    }
}
