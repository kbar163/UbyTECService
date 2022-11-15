using UbyTECService.Models.Generated;

namespace UbyTECService.Models.UbyAdminManagement
{
    //DTO utilizado para respuesta al request de obtener un repartidor por un id dado.
    public class SingleDeliveryman
    {
        public bool exito { get; set; }
        public Repartidor? repartidor { get; set; }
        
    }
}