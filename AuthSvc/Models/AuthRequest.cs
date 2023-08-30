using System.ComponentModel.DataAnnotations;

namespace AuthSvc.Models
{
    public class AuthRequest
    {
        //public string FullName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
        //public string Role { get; set; }
    }
}
