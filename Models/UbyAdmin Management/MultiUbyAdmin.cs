using UbyTECService.Models.Generated;

namespace UbyTECService.Models.UbyAdminManagement
{
    //DTO utilizado para respuesta al request de obtener todos los administradores uby en la base de datos.
    public class MultiUbyAdmin
    {
        public bool exito { get; set; }
        public List<AdminUbyDTO> admin { get; set; } = null!;
        
    }
}