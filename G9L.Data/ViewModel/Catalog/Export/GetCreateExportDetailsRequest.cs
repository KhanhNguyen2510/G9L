using System;

namespace G9L.Data.ViewModel.Catalog.Export
{
    public class GetCreateExportDetailsRequest
    {
        public int ExportID { get; set; }
        public int[] ProductID { get; set; }
    }
}
