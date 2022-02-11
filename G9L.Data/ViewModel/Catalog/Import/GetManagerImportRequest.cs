using G9L.Data.ViewModel.Common;
using System;

namespace G9L.Data.ViewModel.Catalog.Import
{
    public class GetManagerImportRequest : PagedResultBase
    {
        public string KeyWord { get; set; }
        public int? ProviderID { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
    }
}
