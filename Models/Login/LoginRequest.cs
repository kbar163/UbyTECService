namespace UbyTECService.Models
{
    public class LoginRequest
    {
        public string usuario { get; set; } = null!;
        public string password { get; set; } = null!;
    }
}