using G9L.Data.Enum;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace G9L.Data.Entities
{
    [Table("Export")]
    public class Export
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ExportDate { get; set; }// ngày thêm
        [Column(TypeName = "decimal(18,3)")]
        public decimal TotalAmount { get; set; }// tổng tiền
        public IsExport IsExport { get; set; }

        public string UpdateUser { get; set; }
        [Column(TypeName = ("datetime"))]
        public DateTime UpdateDate { get; set; }
        public int CompanyIndex { get; set; }
    }
}
