using UbyTECService.Models.OrderManagement;

namespace UbyTECService.Data.Interfaces
{
    //Esta interfaz dicta el contrato basico a seguir para cualquier
    //implementacion del repositorio que maneja la logica de manejo de pedidos de la solucion.
    public interface IOrderRepository
    {
        // ActionResponse AddOrder(OrderRequest newOrder);
        // ActionResponse ModifyOrder(OrderRequest modOrder);
        // ActionResponse DeleteOrder(IdRequest delOrder);
        SingleOrder GetOrderById(int id);
        MultiOrder GetAllOrders();
    }
}