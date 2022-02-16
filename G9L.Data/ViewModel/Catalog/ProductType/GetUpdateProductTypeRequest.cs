using Microsoft.AspNetCore.Http;

namespace G9L.Data.ViewModel.Catalog.ProductType
{
    public class GetUpdateProductTypeRequest
    {
        public int ProcductTypeID { get; set; }
        public string ProcductTypeName { get; set; }
        public string Image { get; set; }
    }
}
