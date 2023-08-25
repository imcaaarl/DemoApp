using UserSvc.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserSvc.Models
{
    public class User : commonAudit
    {
        public User()
        {
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName ="varchar(255)")]
        public string FullName { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Email { get; set; }

        [Required]
        [Column(TypeName = "varchar(255)")]

        public string Password { get; set; }

        [ForeignKey("UserRole")]
        public int? UserRoleId { get; set; }
        public virtual UserRole tbluserroles { get; set; }
        [ForeignKey("UserType")]
        public int UserTypeId { get; set; }
        public virtual UserType tblusertypes { get; set; }

        public User(string fullName, string email, string password,int userRoleId,int userTypeId)
        {
            FullName = fullName;
            Email = email;
            Password = password;
            UserRoleId = userRoleId;
            UserTypeId = userTypeId;
    }
    }    
}
