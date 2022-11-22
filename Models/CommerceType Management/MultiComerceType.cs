using UbyTECService.Models.Generated;

namespace UbyTECService.Models.CommerceTypeManagement
{
    //DTO utilizado para respuesta al request de obtener todos los tipos de comercio.
    public class MultiCommerceType
    {
        public bool exito { get; set; }
        public List<CommerceType> tipos { get; set; } = null!;
        
    }
}