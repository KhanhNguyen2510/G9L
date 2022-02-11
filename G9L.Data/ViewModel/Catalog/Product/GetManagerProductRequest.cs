using G9L.Data.ViewModel.Common;

namespace G9L.Data.ViewModel.Catalog.Product
{
    public class GetManagerProductRequest : PagedResultBase
    {
        public string KeyWord { get; set; }
        public int? ManufactureID { get; set; }
        public string StorageLocations { get; set; }
    }
}
