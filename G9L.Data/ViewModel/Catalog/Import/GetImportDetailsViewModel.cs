using G9L.Data.Enum;

namespace G9L.Data.ViewModel.Catalog.Import
{
    public class GetImportDetailsViewModel
    {
        public int ImportID { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int Quantily { get; set; }//số lượng
        public decimal CostPrice { get; set; }//giá nhập
        public IsUnit IsUnit { get; set; }// DVT
    }
}
