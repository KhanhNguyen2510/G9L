using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace G9L.Data.Entities
{
    [Table("ManufactureOfProduct")]
    public class ManufactureOfProduct
    {
        public int ProductID { get; set; }
        public int ManufactureID { get; set; }

        public string UpdateUser { get; set; }
        [Column(TypeName = ("datetime"))]
        public DateTime UpdateDate { get; set; }
        public int CompanyIndex { get; set; }
    }
}
