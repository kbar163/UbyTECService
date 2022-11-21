using UbyTECService.Models;
using UbyTECService.Models.CustomerManagement;

namespace UbyTECService.Data.Interfaces
{
    //Esta interfaz dicta el contrato basico a seguir para cualquier
    //implementacion del repositorio que maneja la logica de manejo de clientes de la solucion.
    public interface ICustomerRepository
    {
        ActionResponse AddCustomer(CustomerRequest newCustomer);
        ActionResponse ModifyCustomer(CustomerRequest modCustomer);
        ActionResponse DeleteCustomer(IdRequest delCustomer);
        SingleCustomer GetCustomerById(string id);
        // MultiDeliveryman GetAllDeliverymen();
    }
}