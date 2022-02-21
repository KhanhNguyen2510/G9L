using G9L.Data.ViewModel.Catalog.Mannufacture;
using G9L.Data.ViewModel.Mannufacture;
using G9L.IntergrationAPI.Manufacture;
using G9L.Wedsite.Models;
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
        public async Task<IActionResult> Create([FromForm] GetCreateManufactureRequest request)
        {
            var result = await _manufactureApiClient.CreateToManufacture(request);
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
        public async Task<IActionResult> Update([FromForm] GetUpdateManufactureRequest request)
        {

            var result = await _manufactureApiClient.UpdateToManufacture(request);
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
