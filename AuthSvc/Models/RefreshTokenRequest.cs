namespace AuthSvc.Models
{
    public class RefreshTokenRequest:AuthRequest
    {
        public string RefreshToken { get; set; }
    }
}
