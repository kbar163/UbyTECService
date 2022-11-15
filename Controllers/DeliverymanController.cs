using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using UbyTECService.Data.Interfaces;
using UbyTECService.Models;
using UbyTECService.Models.DeliveryManagement;

namespace UbyTECService.Controllers
{
    //RepartidorController hereda la clase ControllerBase, utilizada para el manejo
    //del endpoints.
    //ApiController identifica a la clase como un controlador en el framework.
    //RepartidorController se encarga de manejar los endpoints que permiten la gestion de repartidores.
    //Route especifica la ruta para este controlador. En este caso local:
    //http://localhost:5068/api/repartidor

    [Route("api/manage/repartidor")]
    [ApiController]
    [EnableCors("Policy")]
    public class DeliverymanController : ControllerBase
    {
        private readonly IDeliverymanRepository _repository;

        public DeliverymanController(IDeliverymanRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public ActionResult<ActionResponse> AddRepartidor(DeliverymanRequest newDeliveryman )
        {
            var response = _repository.AddDeliveryman(newDeliveryman);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public ActionResult<SingleDeliveryman> GetDeliverymanById(string id)
        {
            var response = _repository.GetDeliverymanById(id);
            return Ok(response);
        }

        [HttpGet]
        public ActionResult<MultiDeliveryman> GetAllDeliverymen()
        {
            var response = _repository.GetAllDeliverymen();
            return Ok(response);
        }

        [HttpPatch]
        public ActionResult<ActionResponse> ModifyDeliveryman(DeliverymanRequest modDeliveryman )
        {
            var response = _repository.ModifyDeliveryman(modDeliveryman);
            return Ok(response);
        }

        [HttpDelete]
        public ActionResult<ActionResponse> DeleteDeliveryman(IdRequest delDeliveryman)
        {
            var response = _repository.DeleteDeliveryman(delDeliveryman);
            return Ok(response);
        }
    }
}