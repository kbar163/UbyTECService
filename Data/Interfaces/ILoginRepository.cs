using UbyTECService.Models.Login;

namespace UbyTECService.Data.Interfaces
{
    //Interfaz para el repositorio de logica de login, declara un metodo AuthCheck cuyo proposito es validar datos de entrada
    //de usuario.
    public interface ILoginRepository
    {
        LoginResponse AuthCheck(LoginRequest request);
    }
    
}