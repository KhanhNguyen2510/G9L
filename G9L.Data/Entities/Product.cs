using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace G9L.Data.Entities
{
    [Table("Product")]
    public class Product //sản phẩm
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Name { get; set; }
        public int ManufactureID { get; set; }//nhà cung cấp 
        public  int Quantily { get; set; }//số lượng
        public decimal CostPrice { get; set; } // giá mua vào
        public decimal Price { get; set; } // giá bán 
        public string StorageLocations { get; set; }//vị trí lưu kho
        public string Description { get; set; }//chú thích

        public string UpdateUser { get; set; }
        [Column(TypeName = ("datetime"))]
        public DateTime UpdateDate { get; set; }
        public int CompanyIndex { get; set; }
    }
}


