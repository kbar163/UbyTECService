namespace UbyTECService.Models.UbyAdminManagement
{
    //DTO utilizado para request eliminacion de administradores uby.
    public class DeleteUbyAdminRequest
    {
        public string CedulaAdminUby { get; set; } = null!;
        
    }
}