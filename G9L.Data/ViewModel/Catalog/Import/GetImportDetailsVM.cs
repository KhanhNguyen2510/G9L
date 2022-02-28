using G9L.Data.Enum;

namespace G9L.Data.ViewModel.Catalog.Import
{
    public class GetImportDetailsVM
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int Quantily { get; set; }
        public decimal CostPrice { get; set; }
        public IsUnit IsUnit { get; set; }
    }
}
