using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using UbyTECService.Data.Interfaces;
using UbyTECService.Models;
using UbyTECService.Models.OrderManagement;

namespace UbyTECService.Controllers
{
    //OrderController hereda la clase ControllerBase, utilizada para el manejo
    //de endpoints.
    //ApiController identifica a la clase como un controlador en el framework.
    //OrderController se encarga de manejar los endpoints que permiten la gestion de pedidos.
    //Route especifica la ruta para este controlador. En este caso local:
    //http://localhost:5068/api/manage/pedido

    [Route("api/manage/pedido")]
    [ApiController]
    [EnableCors("Policy")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _repository;

        public OrderController(IOrderRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public ActionResult<ActionResponse> AddOrder(OrderRequest newOrder )
        {
            var response = _repository.AddOrder(newOrder);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public ActionResult<SingleOrder> GetOrderById(int id)
        {
            var response = _repository.GetOrderById(id);
            return Ok(response);
        }

        [HttpGet]
        public ActionResult<MultiOrder> GetAllDeliverymen()
        {
            var response = _repository.GetAllOrders();
            return Ok(response);
        }

        // [HttpPatch]
        // public ActionResult<ActionResponse> ModifyOrder(OrderRequest modOrder )
        // {
        //     var response = _repository.ModifyOrder(modOrder);
        //     return Ok(response);
        // }

        // [HttpDelete]
        // public ActionResult<ActionResponse> DeleteOrder(IdRequest delOrder)
        // {
        //     var response = _repository.DeleteOrder(delOrder);
        //     return Ok(response);
        // }
    }
}