using UserSvc.Models;
using System.ComponentModel.DataAnnotations;

namespace UserSvc.Models
{
    public class User : commonAudit
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FullName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public string Role{get; set; }

        public User(string fullName, string email, string password,string role)
        {
            FullName = fullName;
            Email = email;
            Password = password;
            Role = role;
    }
    }

    
}
