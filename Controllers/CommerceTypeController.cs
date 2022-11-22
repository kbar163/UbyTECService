using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using UbyTECService.Data.Interfaces;
using UbyTECService.Models;
using UbyTECService.Models.CommerceTypeManagement;


namespace UbyTECService.Controllers
{
    //CommerceTypeController hereda la clase ControllerBase, utilizada para el manejo
    //del endpoints.
    //ApiController identifica a la clase como un controlador en el framework.
    //CommerceTypeController se encarga de manejar los endpoints que permiten la gestion de tipos de comercio.
    //Route especifica la ruta para este controlador. En este caso local:
    //http://localhost:5068/api/manage/tipocomercio

    [Route("api/manage/tipocomercio")]
    [ApiController]
    [EnableCors("Policy")]
    public class CommerceTypeController : ControllerBase
    {
        private readonly ICommerceTypeRepository _repository;

        public CommerceTypeController(ICommerceTypeRepository repository)
        {
            _repository = repository;
        }


        [HttpGet]
        public ActionResult<MultiCommerceType> GetAllCommerceTypes()
        {
            var response = _repository.GetAllCommerceTypes();
            return Ok(response);
        }
        
        [HttpPost]
        public ActionResult<ActionResponse> AddCustomer(CommerceTypeRequest newCommerce)
        {
            var response = _repository.AddCommerceType(newCommerce);
            return Ok(response);
        }

        [HttpPatch]
        public ActionResult<ActionResponse> ModCustomer(ModCommerceRequest newCommerce)
        {
            var response = _repository.ModifyCommerceType(newCommerce);
            return Ok(response);
        }

        [HttpDelete]
        public ActionResult<ActionResponse> DelCustomer(NumIdRequest delCommerce)
        {
            var response = _repository.DeleteCommereceType(delCommerce);
            return Ok(response);
        }
    }
}