using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace G9L.Data.Entities
{
    [Table("UnitProduct")]
    public class UnitProduct
    {
        [Key]
        public int ProductID { get; set; }
        /// <summary>
        /// Số lượng trong thùng
        /// </summary>
        public int NumberInBarrel { get; set; }
    }
}
