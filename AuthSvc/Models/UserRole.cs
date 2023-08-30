using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AuthSvc.Models
{
    public class UserRole
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string Role { get; set; }
        public int UserRoleCode { get; set; }
    }
}
