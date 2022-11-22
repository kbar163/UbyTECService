using UbyTECService.Models.Generated;

namespace UbyTECService.Models.ProductManagement
{
    //DTO utilizado para respuesta al request de obtener todos los productos en la base de datos.
    public class MultiCategory
    {
        public bool exito { get; set; }
        public List<Category> categorias { get; set; } = null!;
        
    }
}