using G9L.Data.Enum;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace G9L.Data.Entities
{
    [Table("ImportDetails")]
    public class ImportDetails
    {
        public int ImportID { get; set; }
        public int ProductID { get; set; }//mã sản phẩm
        public int Quantily { get; set; }//số lượng
        public decimal CostPrice { get; set; }//giá nhập
        public IsUnit IsUnit { get; set; }// DVT

        public string UpdateUser { get; set; }
        [Column(TypeName = ("datetime"))]
        public DateTime UpdateDate { get; set; }
        public int CompanyIndex { get; set; }
    }
}
