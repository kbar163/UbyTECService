using UbyTECService.Models.Generated;

namespace UbyTECService.Models.DeliveryManagement
{
    //DTO utilizado para respuesta al request de obtener todos los repartidores en la base de datos.
    public class MultiDeliveryman
    {
        public bool exito { get; set; }
        public List<DeliverymanDTO> repartidores { get; set; } = null!;
        
    }
}