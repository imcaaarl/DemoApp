using AuthSvc.Models;
using System.ComponentModel.DataAnnotations;

namespace AuthSvc.Models
{
    public class UserAccount: commonAudit
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

    }

    
}
