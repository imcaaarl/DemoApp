namespace AuthSvc.Models
{
    public class AuthResponse
    {
        public string Email { get; set; }
        public string JwtToken { get; set; }
        public int ExpiresIn { get; set; }
    }
}
