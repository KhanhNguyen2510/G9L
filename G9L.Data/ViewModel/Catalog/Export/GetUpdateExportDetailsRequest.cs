namespace G9L.Data.ViewModel.Catalog.Export
{
    public class GetUpdateExportDetailsRequest
    {
        public int ExportID { get; set; }
        public int ProductID { get; set; }
        public int? Quantily { get; set; }//số lượng
        public decimal? CostPrice { get; set; }//giá nhập
        public string Unit { get; set; }// DVT

        public string UpdateUser { get; set; }
    }
}
