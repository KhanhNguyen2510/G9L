using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace G9L.Data.Entities
{
    [Table("ExportDetails")]
    public class ExportDetails
    {
        public int ExportID { get; set; } //mã xuất hàng
        public int ProductID { get; set; }//mã sản phẩm

        public string UpdateUser { get; set; }
        [Column(TypeName = ("datetime"))]
        public DateTime UpdateDate { get; set; }
        public int CompanyIndex { get; set; }
    }
}
