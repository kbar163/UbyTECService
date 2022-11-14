namespace UbyTECService.Models.Login
{
    //Modelo de datos utilizado para mapear un request proveniente de frontend
    //para realizar un intento de login, se reciben las credenciales del usuario
    //que desea loguearse.
    public class LoginRequest
    {
        public string usuario { get; set; } = null!;
        public string password { get; set; } = null!;
    }
}