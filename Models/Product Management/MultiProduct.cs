using UbyTECService.Models.Generated;

namespace UbyTECService.Models.ProductManagement
{
    //DTO utilizado para respuesta al request de obtener todos los productos en la base de datos.
    public class MultiProduct
    {
        public bool exito { get; set; }
        public List<ProductDTO> productos { get; set; } = null!;
        
    }
}