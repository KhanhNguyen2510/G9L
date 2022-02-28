using G9L.Data.Enum;

namespace G9L.Data.ViewModel.Catalog.Export
{
    public class GetCreateExportDetailsRequest
    {
        public int ExportID { get; set; }
        public int ProductID { get; set; }
        public int Quantily { get; set; }
        public IsUnit IsUnit { get; set; }
    }
}
