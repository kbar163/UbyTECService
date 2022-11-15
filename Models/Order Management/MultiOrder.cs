namespace UbyTECService.Models.OrderManagement
{
    //DTO utilizado para respuesta al request de obtener todos los productos en la base de datos.
    public class MultiOrder
    {
        public bool exito { get; set; }
        public List<OrderDTO> pedidos { get; set; } = null!;
        
    }
}