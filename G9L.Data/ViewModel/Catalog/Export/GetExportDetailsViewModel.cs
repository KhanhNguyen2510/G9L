namespace G9L.Data.ViewModel.Catalog.Export
{
    public class GetExportDetailsViewModel
    {
        public int ExportID { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
