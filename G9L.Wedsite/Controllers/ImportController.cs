using G9L.Data.Enum;
using G9L.Data.ViewModel.Catalog.Import;
using G9L.IntergrationAPI.Import;
using G9L.IntergrationAPI.Provider;
using G9L.Wedsite.Models;
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
                Text = x.ProviderName,
                Value = x.ProviderID.ToString(),
                Selected = ProviderID == x.ProviderID
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
        public async Task<IActionResult> IndexUpdate(int ImportID)
        {
            var data = await _importApiClient.GetListImportAndImportDetails(ImportID);

            ViewBag.Import = ImportID;
            
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
        public async Task<IActionResult> Create([FromForm] GetAddImport request, GetAddImport.GetQuantily quantily, GetAddImport.GetProduct product, GetAddImport.GetIsUnit isUnit, GetAddImport.GetCostPrice costPrice)
        {

            var getQuantily = new int?[]
            {
                quantily.Quantily_1,
                quantily.Quantily_2,
                quantily.Quantily_3,
                quantily.Quantily_4,
                quantily.Quantily_5,
                quantily.Quantily_6,
                quantily.Quantily_7,
                quantily.Quantily_8,
                quantily.Quantily_9,
                quantily.Quantily_10
            };
            var getProduct = new int?[]
            {
                product.ProductID_1,
                product.ProductID_2,
                product.ProductID_3,
                product.ProductID_4,
                product.ProductID_5,
                product.ProductID_6,
                product.ProductID_7,
                product.ProductID_8,
                product.ProductID_9,
                product.ProductID_10,
            };                   
            var getIsUnit = new IsUnit?[]
            {
                isUnit.IsUnit_1,
                isUnit.IsUnit_2,
                isUnit.IsUnit_3,
                isUnit.IsUnit_4,
                isUnit.IsUnit_5,
                isUnit.IsUnit_6,
                isUnit.IsUnit_7,
                isUnit.IsUnit_8,
                isUnit.IsUnit_9,
                isUnit.IsUnit_10
            };
            var getCostPrice = new decimal?[]
            {
                costPrice.CostPrice_1,
                costPrice.CostPrice_2,
                costPrice.CostPrice_3,
                costPrice.CostPrice_4,
                costPrice.CostPrice_5,
                costPrice.CostPrice_6,
                costPrice.CostPrice_7,
                costPrice.CostPrice_8,
                costPrice.CostPrice_9,
                costPrice.CostPrice_10,
            };

            for (int i = 0; i < getProduct.Length; i++)
            {
                if (getProduct[i] is 0 or null)
                {
                    break;
                }
                for (int j = i + 1; j <= getProduct.Length; j++)
                {
                    if (getProduct[j] is 0 or null)
                    {
                        break;
                    }
                    if (getProduct[i] == getProduct[j])
                    {
                        await _importApiClient.DeleteToImport(request.ImportID);
                        TempData["Error"] = MessageModel.AddImtemFaledDuplicate();
                        return RedirectToAction("Index");
                    }
                }
            }
            int numberSussces = 0;
            for (int i = 0; i < getProduct.Length; i++)
            {
                if (getProduct[i] is 0 or null)
                {
                    break;
                }
                var data = new GetCreateImportDetailsRequest()
                {
                    ImportID = request.ImportID,
                    ProductID = (int)getProduct[i],
                    CostPrice = getCostPrice[i],
                    IsUnit = getIsUnit[i],
                    Quantily = getQuantily[i]
                };

                var result = await _importApiClient.CreateToImportDetails(data);

                if (result == false)
                {
                    await _importApiClient.DeleteToImport(request.ImportID);
                    TempData["Error"] = MessageModel.AddItemFaled();
                    return RedirectToAction("Index");
                }
                numberSussces++;
            }
            if (numberSussces > 0)
            {
                TempData["Success"] = MessageModel.AddItemSuccessful();
            }
            else
            {
                await _importApiClient.DeleteToImport(request.ImportID);
                TempData["Error"] = MessageModel.AddItemNoSucces();
            }

            return RedirectToAction("Index");
        }
    }
}
