using System.ComponentModel.DataAnnotations;

namespace G9L.Data.ViewModel.Catalog.Product
{
    public class GetCreateProductRequest
    {
        public string ProductName { get; set; }
        public int? ManufactureID { get; set; }//nhà cung cấp 
        public int? Quantily { get; set; }//số lượng
        public decimal? Price { get; set; }
        public string StorageLocations { get; set; }//vị trí lưu kho
        public string Description { get; set; }//chú thích
        [Required]
        public int ProductTypeID { get; set; }
        public string Image1 { get; set; }
        public string Image2 { get; set; }
        public string Image3 { get; set; }
    }
}
