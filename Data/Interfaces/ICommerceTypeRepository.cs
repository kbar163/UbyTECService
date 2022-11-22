using UbyTECService.Models;
using UbyTECService.Models.CommerceTypeManagement;

namespace UbyTECService.Data.Interfaces
{
    //Esta interfaz dicta el contrato basico a seguir para cualquier
    //implementacion del repositorio que maneja la logica de manejo de tipos de comercio de la solucion.
    public interface ICommerceTypeRepository
    {
        
        MultiCommerceType GetAllCommerceTypes();
        
    }
}