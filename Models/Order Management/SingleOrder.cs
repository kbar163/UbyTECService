namespace UbyTECService.Models.OrderManagement
{
    //DTO utilizado para respuesta al request de obtener un producto por un id dado.
    public class SingleOrder
    {
        public bool exito { get; set; }
        public OrderDTO? pedido { get; set; }
        
    }
}