using UbyTECService.Models;
using UbyTECService.Models.DeliveryManagement;
using UbyTECService.Models.Generated;
using UbyTECService.Models.Generated;
using UbyTECService.Models.UbyAdminManagement;

namespace UbyTECService.Data.Interfaces
{
    //Esta interfaz dicta el contrato basico a seguir para cualquier
    //implementacion del repositorio que maneja la logica de manejo de repartidores de la solucion.
    public interface IDeliverymanRepository
    {
        ActionResponse AddDeliveryman(DeliverymanRequest newDeliveryman);
        ActionResponse ModifyDeliveryman(DeliverymanRequest modDeliveryman);
        ActionResponse DeleteDeliveryman(IdRequest delAdmin);
        SingleDeliveryman GetDeliverymanById(string id);
        MultiDeliveryman GetAllDeliverymen();
    }
}