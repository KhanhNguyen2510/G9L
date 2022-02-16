using G9L.Data.Enum;
using G9L.Data.ViewModel.Catalog.Export;
using G9L.IntergrationAPI.Export;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace G9L.Wedsite.Controllers
{
    public class ExportController : Controller
    {
        private readonly IExportApiClient _exportApiClient;
        public ExportController(IExportApiClient exportApiClient)
        {
            _exportApiClient = exportApiClient;
        }
        public async Task<IActionResult> ExportIndex(string KeyWord , IsExport IsExport, int ProviderID, DateTime DateFrom, DateTime DateTo, int PageIndex = 1, int PageSize = 1000)
        {

            var request = new GetManagerExportRequest()
            {
                KeyWord = KeyWord,
                IsExport = IsExport,
                DateFrom = DateFrom,
                DateTo = DateTo,
                PageIndex = PageIndex,
                PageSize = PageSize
            };

            var data = await _exportApiClient.GetListToExport(request);

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
        public async Task<IActionResult> ExportDetailsIndex(int ExportID)
        {
            var data = await _exportApiClient.GetListToExportDetails(ExportID);

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
