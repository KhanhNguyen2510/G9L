using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace G9L.Data.Entities
{
    [Table("Account")]
    public class Account
    {
        [Key]
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string AccountPrivilege { get; set; }

        public int CompanyIndex { get; set; }
        [Column(TypeName = ("datetime"))]
        public DateTime CreateDate { get; set; }
        [Column(TypeName = ("datetime"))]
        public DateTime UpdateDate { get; set; }
        public string UpdateUser { get; set; }
    }
}
