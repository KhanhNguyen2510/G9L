using G9L.Data.Enum;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace G9L.Data.Entities
{
    [Table("ExportDetails")]
    public class ExportDetails
    {
        public int ExportID { get; set; } //mã xuất hàng
        public int ProductID { get; set; }//mã sản phẩm
        public int Quantily { get; set; }
        public IsUnit IsUnit { get; set; }

        public string UpdateUser { get; set; }
        [Column(TypeName = ("datetime"))]
        public DateTime UpdateDate { get; set; }
        public int CompanyIndex { get; set; }
    }
}
