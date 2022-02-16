using G9L.Aplication.Catalog.ProductType;
using G9L.BackEndAPI.Common;
using G9L.Common.SystemBase;
using G9L.Data.ViewModel.Catalog.ProductType;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;

namespace G9L.BackEndAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductTypeController : ApiControllerBase
    {
        private readonly IProductTypeSevice _productTypeSevice;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductTypeController(IProductTypeSevice productTypeSevice , IWebHostEnvironment webHostEnvironment) : base()
        {
            _productTypeSevice = productTypeSevice;
            _webHostEnvironment = webHostEnvironment;
        }
        //Create
        [HttpPost("CreateToProductType")]
        public async Task<JsonResult> CreateToProductType([FromForm] GetCreateProductTypeRequest request, IFormFile formFile)
        {
            string file = "";
            if (formFile != null) file = UploadImage(formFile);

            var result = new GetCreateProductTypeRequest()
            {
                Name = request.Name,
                Image = file

            };
            var data = await _productTypeSevice.CreateToProductType(result, _CurrentCompanyIndex, _CurrentUpdateUser);
            return Json(data);
        }
        //Update
        [HttpPost("UpdateToProductType")]
        public async Task<JsonResult> UpdateToProductType([FromForm] GetUpdateProductTypeRequest request)
        {
            var data = await _productTypeSevice.UpdateToProductType(request, _CurrentCompanyIndex, _CurrentUpdateUser);
            return Json(data);
        }
        [HttpPost("UploadImage")]
        public string UploadImage(IFormFile FileImage)
        {
            try
            {
                if (FileImage == null) return null;

                else if (FileImage.Length > 0)
                {
                    if (!Directory.Exists(_webHostEnvironment.WebRootPath + "\\Image\\"))
                    {
                        Directory.CreateDirectory(_webHostEnvironment.WebRootPath + "\\Image\\");
                    }
                    using (FileStream fileStream = System.IO.File.Create(_webHostEnvironment.WebRootPath + "\\Image\\" + FileImage.FileName))
                    {
                        FileImage.CopyTo(fileStream);
                        fileStream.Flush();
                        return SystemConnection.UploadImageConnection + "/Image/" + FileImage.FileName;
                    }
                }else return null;
            }
            catch (Exception)
            {
                return null;
            }
        }
        //Delete
        [HttpPost("DeleteToProductType/{ProductTypeID}")]
        public async Task<JsonResult> DeleteToProductType(int ProductTypeID)
        {
            var data = await _productTypeSevice.DeleteToProductType(ProductTypeID, _CurrentCompanyIndex);
            return Json(data);
        }
        //List
        [HttpGet("GetListToProductType")]
        public async Task<JsonResult> GetListToProductType([FromQuery] GetManagerProductTypeRequest request)
        {
            var data = await _productTypeSevice.GetListToProductType(request, _CurrentCompanyIndex);
            return Json(data);
        }
        [HttpGet("GetToProductType/{ProductTypeID}")]
        public async Task<JsonResult> GetToProductType(int ProductTypeID)
        {
            var data = await _productTypeSevice.GetToProductType(ProductTypeID, _CurrentCompanyIndex);
            return Json(data);
        }
    }
}
