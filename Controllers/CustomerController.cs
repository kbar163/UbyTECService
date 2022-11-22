using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using UbyTECService.Data.Interfaces;
using UbyTECService.Models;
using UbyTECService.Models.CustomerManagement;
using UbyTECService.Models.DeliveryManagement;

namespace UbyTECService.Controllers
{
    //CustomerController hereda la clase ControllerBase, utilizada para el manejo
    //del endpoints.
    //ApiController identifica a la clase como un controlador en el framework.
    //CustomerController se encarga de manejar los endpoints que permiten la gestion de clientes.
    //Route especifica la ruta para este controlador. En este caso local:
    //http://localhost:5068/api/cliente

    [Route("api/manage/cliente")]
    [ApiController]
    [EnableCors("Policy")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _repository;

        public CustomerController(ICustomerRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public ActionResult<ActionResponse> AddCustomer(CustomerRequest newCustomer)
        {
            var response = _repository.AddCustomer(newCustomer);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public ActionResult<SingleCustomer> GetCustomerById(string id)
        {
            var response = _repository.GetCustomerById(id);
            return Ok(response);
        }

    

        [HttpPatch]
        public ActionResult<ActionResponse> ModifyCustomer(CustomerRequest modCustomer )
        {
            var response = _repository.ModifyCustomer(modCustomer);
            return Ok(response);
        }

        [HttpDelete]
        public ActionResult<ActionResponse> DeleteCustomer(IdRequest delCustomer)
        {
            var response = _repository.DeleteCustomer(delCustomer);
            return Ok(response);
        }
    }
}