using Microsoft.EntityFrameworkCore;
using UbyTECService.Data.Context;
using UbyTECService.Data.Interfaces;
using UbyTECService.Models.Login;

namespace UbyTECService.Data.Repositories
{
    //Implementacion de la logica para cada una de los endpoints expuesos en LoginController,
    //esta clase extiende la interfaz ILoginRepository, e implementa los metodos relacionados
    //a la manipulacion de datos necesaria para cumplir con los requerimientos funcionales
    //de la aplicacion.
    public class LoginRepository : ILoginRepository
    {
        private readonly ubytecdbContext _context;

        public LoginRepository(ubytecdbContext context)
        {
            _context = context;
        }

        //Entrada: LoginRequest request: Instancia de clase de modelo de datos que contiene
        //la informacion que fue enviada desde la aplicacion cliente.
        //Proceso: Punto de entrada del proceso de autenticacion, hace uso de funciones
        //SQL que obtienen informacion de la base de datos y la comparan con la informacion
        //recibida.
        //Salida: LoginResponse response: Indica mediante valores booleanos el resultado del intento
        //de login y el tipo de usuario que esta haciendo login.
        public LoginResponse AuthCheck(LoginRequest request)
        {
            LoginResponse response = new LoginResponse();

            try
            {
                bool result = false;

                result = _context.ValidateUbyAdmins.FromSqlRaw("SELECT VALIDATE_UBY_ADMIN_CREDENTIALS({0},{1});",request.usuario,request.password).ToList()[0].isValid;
                if(result)
                {
                    response.logged = true;
                    response.tipo = 0;
                    return response;
                }

                result = _context.ValidateAfiAdmins.FromSqlRaw("SELECT VALIDATE_AFI_ADMIN_CREDENTIALS({0},{1});",request.usuario,request.password).ToList()[0].isValid;
                if(result)
                {
                    response.logged = true;
                    response.tipo = 1;
                    return response;    
                }

                result = _context.ValidateCustomers.FromSqlRaw("SELECT VALIDATE_CUSTOMER_CREDENTIALS({0},{1});",request.usuario,request.password).ToList()[0].isValid;
                if(result)
                {
                    response.logged = true;
                    response.tipo = 2;
                    return response;
                }
                
            }
            catch (Exception e)
            {
                response.logged = false;
                response.tipo = -1;
            }

            return response;
        }
    }
}