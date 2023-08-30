using System.ComponentModel.DataAnnotations.Schema;

namespace AuthSvc.Models
{
    public class UserAccount
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int UserRoleId { get; set; }
        public virtual UserRole tbluserroles { get; set; }
        public int UserTypeId { get; set; }
        public virtual UserType tblusertypes { get; set; }
    }
}
