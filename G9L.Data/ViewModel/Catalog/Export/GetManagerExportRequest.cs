using G9L.Data.Enum;
using G9L.Data.ViewModel.Common;
using System;

namespace G9L.Data.ViewModel.Catalog.Export
{
    public class GetManagerExportRequest : PagingRequestBase
    {
        public string KeyWord { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public IsExport? IsExport { get; set; }
    }
}
