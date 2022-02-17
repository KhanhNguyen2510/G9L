using G9L.Data.ViewModel.Catalog.Import;
using G9L.IntergrationAPI.Import;
using G9L.IntergrationAPI.Provider;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace G9L.Wedsite.Controllers
{
    public class ImportController : Controller
    {
        private readonly IImportApiClient _importApiClient;
        private readonly IProviderApiClient _providerApiClient;
        public ImportController(IImportApiClient importApiClient, IProviderApiClient providerApiClient)
        {
            _providerApiClient = providerApiClient;
            _importApiClient = importApiClient;
        }
        public async Task<IActionResult> Index(string KeyWord, int? ProviderID, DateTime? DateFrom, DateTime? DateTo, int PageIndex = 1, int PageSize = 1000)
        {

            var request = new GetManagerImportRequest()
            {
                KeyWord = KeyWord,
                ProviderID = ProviderID,
                DateFrom = DateFrom,
                DateTo = DateTo,
                PageIndex = PageIndex,
                PageSize = PageSize
            };

            var data = await _importApiClient.GetListToImport(request);

            var pr = await _providerApiClient.GetToProvideOnNameAndID();
            ViewBag.Provider = pr.Select(x => new SelectListItem()
            {
                Text =x.ProviderName,
                Value = x.ProviderID.ToString(),
                Selected = ProviderID == x.ProviderID
            });

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
        public async Task<IActionResult> ImportDetailsIndex(int ImportID)
        {
            var data = await _importApiClient.GetListToImportDetails(ImportID);

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
