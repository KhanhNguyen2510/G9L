using G9L.Data.ViewModel.Catalog.Provider;
using G9L.IntergrationAPI.Provider;
using G9L.Wedsite.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace G9L.Wedsite.Controllers
{
    public class ProviderController : Controller
    {
        private readonly IProviderApiClient _providerApiClient;
        public ProviderController(IProviderApiClient providerApiClient)
        {
            _providerApiClient = providerApiClient;
        }
        public async Task<IActionResult> Index(string KeyWord, int PageIndex = 1, int PageSize = 1000)
        {

            var request = new GetManagerProviderRequest()
            {
                KeyWord = KeyWord,
                PageIndex = PageIndex,
                PageSize = PageSize
            };

            var data = await _providerApiClient.GetListToProvider(request);

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

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Create([FromForm]GetCreateProviderRequest request)
        {
            var result = await _providerApiClient.CreateToProvider(request);
            if (result == true)
            {
                TempData["result"] = MessageModel.AddItemSuccessful();
            }
            else
            {
                TempData["resultErro"] = MessageModel.AddItemFaled();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Update([FromForm] GetUpdateProviderRequest request)
        {
            if (request.NumberPhone == null && request.Address == null && request.ProviderName == null)
                return View();

            var result = await _providerApiClient.UpdateToProvider(request);
            if (result == true)
            {
                TempData["result"] = MessageModel.AddItemSuccessful();
            }
            else
            {
                TempData["resultErro"] = MessageModel.AddItemFaled();
            }
            return RedirectToAction("Index");
        }
    }
}
