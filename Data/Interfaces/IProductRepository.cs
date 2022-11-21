using UbyTECService.Models;
using UbyTECService.Models.DeliveryManagement;
using UbyTECService.Models.Generated;
using UbyTECService.Models.ProductManagement;

namespace UbyTECService.Data.Interfaces
{
    //Esta interfaz dicta el contrato basico a seguir para cualquier
    //implementacion del repositorio que maneja la logica de manejo de productos de la solucion.
    public interface IProductRepository
    {
        ActionResponse AddProduct(ProductRequest newProduct);
        ActionResponse ModifyProduct(ProductRequest modProduct);
        ActionResponse DeleteProduct(NumIdRequest delProduct);
        SingleProduct GetProductById(int id);
        MultiProduct GetAllProducts();
        MultiProduct GetProductsByUser(string id);
    }
}