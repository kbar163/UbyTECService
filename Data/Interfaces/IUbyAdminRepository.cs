using UbyTECService.Models;
using UbyTECService.Models.Generated;
using UbyTECService.Models.Generated;
using UbyTECService.Models.UbyAdminManagement;

namespace UbyTECService.Data.Interfaces
{
    //Esta interfaz dicta el contrato basico a seguir para cualquier
    //implementacion del repositorio que maneja la logica de manejo de administradores uby de la solucion.
    public interface IUbyAdminRepository
    {
        ActionResponse AddUbyAdmin(UbyAdminRequest newAdmin);
        ActionResponse ModifyUbyAdmin(UbyAdminRequest modAdmin);
        ActionResponse DeleteUbyAdmin(DeleteUbyAdminRequest delAdmin);
        SingleUbyAdmin GetUbyAdminById(string id);
        MultiUbyAdmin GetAllUbyAdmin();
    }
}