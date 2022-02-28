using G9L.Data.Enum;

namespace G9L.Data.ViewModel.Catalog.Import
{
    public class GetCreateImportDetailsRequest
    {
        public int ImportID { get; set; }
        public int ProductID { get; set; }//mã sản phẩm
        public int? Quantily { get; set; }//số lượng
        public decimal? CostPrice { get; set; }//giá nhập
        public IsUnit? IsUnit { get; set; }// DVT
    }
}
