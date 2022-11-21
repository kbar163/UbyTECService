using UbyTECService.Models.Generated;

namespace UbyTECService.Models.CustomerManagement
{
    //DTO utilizado para respuesta al request de obtener un repartidor por un id dado.
    public class SingleCustomer
    {
        public bool exito { get; set; }
        public CustomerRequest? customer { get; set; }
        
    }
}