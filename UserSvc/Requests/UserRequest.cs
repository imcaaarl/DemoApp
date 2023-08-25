using System.ComponentModel.DataAnnotations;

namespace UserSvc.Requests
{
    public class UserRequest
    {
        public string FullName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
