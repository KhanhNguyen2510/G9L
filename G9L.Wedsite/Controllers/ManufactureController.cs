using G9L.Data.ViewModel.Catalog.Mannufacture;
using G9L.IntergrationAPI.Manufacture;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace G9L.Wedsite.Controllers
{
    public class ManufactureController : Controller
    {
        private readonly IManufactureApiClient _manufactureApiClient;
        public ManufactureController(IManufactureApiClient manufactureApiClient)
        {
            _manufactureApiClient = manufactureApiClient;
        }
        public async Task<IActionResult> Index(string KeyWord, int PageIndex = 1, int PageSize = 1000)
        {

            var request = new GetManagerManufactureRequest()
            {
                KeyWord = KeyWord,
                PageIndex = PageIndex,
                PageSize = PageSize
            };

            var data = await _manufactureApiClient.GetListToManufacture(request);

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
