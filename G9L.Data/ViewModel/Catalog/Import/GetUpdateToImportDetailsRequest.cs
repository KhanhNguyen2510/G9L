using G9L.Data.Enum;

namespace G9L.Data.ViewModel.Catalog.Import
{
    public class GetUpdateToImportDetailsRequest
    {
        public int ImportID { get; set; }
        public int ProductID { get; set; }
        public int? Quantily { get; set; }
        public decimal? CostPrice { get; set; }
        public IsUnit? IsUnit { get; set; }
    }
}
