using UbyTECService.Models.Generated;

namespace UbyTECService.Models.ProductManagement
{
    //DTO utilizado para respuesta al request de obtener un producto por un id dado.
    public class SingleProduct
    {
        public bool exito { get; set; }
        public ProductDTO? producto { get; set; }
        
    }
}