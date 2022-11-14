using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using UbyTECService.Data.Interfaces;
using UbyTECService.Models.Login;

namespace UbyTECService.Controllers
{
    //LoginController hereda la clase ControllerBase, utilizada para el manejo
    //del endpoints.
    //ApiController identifica a la clase como un controlador en el framework.
    //LoginController se encarga de manejar el endpoint que permite a los usuarios hacer login.
    //Route especifica la ruta para este controlador. En este caso local:
    //http://localhost:5068/api/login

    [Route("api/login")]
    [ApiController]
    [EnableCors("Policy")]
    public class LoginController : ControllerBase
    {
        private readonly ILoginRepository _repository;

        public LoginController(ILoginRepository repository)
        {
            _repository = repository;
        }
        
        
        // POST api/login
        [HttpPost]
        public ActionResult<LoginResponse> Authenticate(LoginRequest request)
        {

            var response = _repository.AuthCheck(request);
            if(response.logged){
                return Ok(response);
            }
            else
            {
                return Unauthorized(response);
            }
            
            

        }
        
    }
}
