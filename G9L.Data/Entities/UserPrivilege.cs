using G9L.Data.Enum;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace G9L.Data.Entities
{
    [Table("UserPrivilege")]
    public class UserPrivilege
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Index { get; set; }
        public string Name { get; set; }
        public IsAdmin IsAdmin { get; set; }
        public string Note { get; set; }

        [Column(TypeName = ("datetime"))]
        public DateTime CreateDate { get; set; }
        [Column(TypeName = ("datetime"))]
        public DateTime UpdateDate { get; set; }
        public string UpdateUser { get; set; }
        public int CompanyIndex { get; set; }
    }
}
