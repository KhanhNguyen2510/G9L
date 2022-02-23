using G9L.Data.Enum;
using G9L.Data.ViewModel.Catalog.Export;
using G9L.IntergrationAPI.Export;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<IActionResult> Index(string KeyWord, IsExport? IsExport, DateTime? DateFrom, DateTime? DateTo, int PageIndex = 1, int PageSize = 1000)
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


            var rs = new List<GetIsExport>()
            {
                 new GetIsExport(){ ID = Data.Enum.IsExport.SuccessExport , Name = "Đã duyệt đơn hàng"},
                 new GetIsExport(){ ID = Data.Enum.IsExport.UnSuccessExport , Name = "Chưa duyệt đơn hàng"}
            };

            ViewBag.IsExport = rs.Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.ID.ToString(),
                Selected = IsExport == x.ID
            });

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
