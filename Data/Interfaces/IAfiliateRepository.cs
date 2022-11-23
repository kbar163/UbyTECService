using UbyTECService.Models;
using UbyTECService.Models.AfiliateManagement;

namespace UbyTECService.Data.Interfaces
{
    //Esta interfaz dicta el contrato basico a seguir para cualquier
    //implementacion del repositorio que maneja la logica de manejo de afiliados de la solucion.
    public interface IAfiliateRepository
    {
        ActionResponse AddAfiliate(AfiliateData newAfiliate);
        ActionResponse ModifyAfiliate(AfiliateDTO modAfiliate);
        ActionResponse ModifyAfiAdmin(AdminAfiDTO modAfiliate);
        SingleAfiliate GetAfiliateById(string id);
        IdRequest GetAfiliateByUsr(string id);
        MultiAfiliate GetAllAfiliates();
        MultiAfiliate GetAfiliatesByProvince(string province);
        ActionResponse ReplaceAfiAdmin(ReplaceAdminRequest newAdmin);
    }
    
}