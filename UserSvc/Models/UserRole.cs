using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserSvc.Models
{
    public class UserRole:commonAudit

    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string Role { get; set; }
        public int UserRoleCode { get; set; }
        public virtual User tblusers { get; set; }

        //public UserRoles() { }
    }
}
