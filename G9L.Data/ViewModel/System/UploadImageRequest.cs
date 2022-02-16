using Microsoft.AspNetCore.Http;

namespace G9L.Data.ViewModel.System
{
    public class UploadImageRequest
    {
        public IFormFile FileImage { get; set; }
    }
}
