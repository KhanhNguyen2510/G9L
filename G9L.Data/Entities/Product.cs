using G9L.Data.Enum;
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
        public int ProductTypeID { get; set; }// Loại hàng
        public int ManufactureID { get; set; }//nhà cung cấp 
        public  int Quantily { get; set; }//số lượng
        [Column(TypeName = "decimal(18,3)")]
        public decimal CostPrice { get; set; } // giá mua vào
        [Column(TypeName = "decimal(18,3)")]
        public decimal Price { get; set; } // giá bán
        public string OldPrice { get; set; }
        /// <summary>
        /// vị trí lưu kho
        /// </summary>
        public string StorageLocations { get; set; }
        public IsUnit IsUnit { get; set; }
        public string Image1 { get; set; } 
        public string Image2 { get; set; }
        public string Image3 { get; set; }
        public string Description { get; set; }//chú thích

        public string UpdateUser { get; set; }
        [Column(TypeName = ("datetime"))]
        public DateTime UpdateDate { get; set; }
        public int CompanyIndex { get; set; }
    }
}


