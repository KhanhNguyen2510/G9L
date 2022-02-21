namespace G9L.Data.ViewModel.Catalog.Product
{
    public class GetManagerProductViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string ManufactureName { get; set; }//nhà cung cấp 
        public int ManufactureID { get; set; }
        public string Local { get; set; }
        public int Quantily { get; set; }//số lượng
        public decimal CostPrice { get; set; }
        public decimal Price { get; set; }
        public string StorageLocations { get; set; }//vị trí lưu kho
        public string ProductTypeName { get; set; }
        public int ProductTypeID { get; set; }
        public string Image1 { get; set; }
        public string Image2 { get; set; }
        public string Image3 { get; set; }
        public string Description { get; set; }//chú thích

    }
}
