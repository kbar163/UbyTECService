namespace UbyTECService.Models.Login
{
    //Modelo de datos utilizado como respuesta al frontend por un intento de login de parte de un usuario
    //logged es una propiedad booleana que indica si el intento fue exitoso o no.
    //tipo se refiere al tipo de usuario que esta haciendo el intento de login
    //tipo = 0 cuando el usuario es un administrador de ubyTEC
    //tipo = 1 cuando el usuario es un administrador de comercio afiliado
    //tipo = 2 cuando el usuario es un cliente de comercio afiliado
    public class LoginResponse
    {
        public bool logged { get; set; }
        public int tipo { get; set; }
    }
}