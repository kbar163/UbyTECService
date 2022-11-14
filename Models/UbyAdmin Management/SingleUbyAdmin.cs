using UbyTECService.Models.Generated;

namespace UbyTECService.Models.UbyAdminManagement
{
    //DTO utilizado para respuesta al request de obtener administradores uby por un id dado.
    public class SingleUbyAdmin
    {
        public bool exito { get; set; }
        public AdministradorUby? admin { get; set; }
        
    }
}