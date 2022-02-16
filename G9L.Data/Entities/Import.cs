using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace G9L.Data.Entities
{
    [Table("Import")]
    public class Import
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int ProviderID { get; set; }//nhà cung cấp
        [Column(TypeName = ("datetime"))]
        public DateTime ImportDate { get; set; }// ngày thêm
        [Column(TypeName = "decimal(18,3)")]
        public decimal TotalAmount { get; set; }// tổng tiền

        public string UpdateUser { get; set; }
        [Column(TypeName = ("datetime"))]
        public DateTime UpdateDate { get; set; }
        public int CompanyIndex { get; set; }
    }
}
