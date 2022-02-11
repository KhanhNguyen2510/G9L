namespace G9L.Data.ViewModel.Catalog.Product
{
    public class GetUpdateProductRequest
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int? ManufactureID { get; set; }//nhà cung cấp 
        public int? Quantily { get; set; }//số lượng
        public decimal? Price { get; set; }
        public string StorageLocations { get; set; }//vị trí lưu kho
        public string Description { get; set; }//chú thích
    }
}
