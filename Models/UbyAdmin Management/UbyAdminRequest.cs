namespace UbyTECService.Models.UbyAdminManagement
{
    //DTO utilizado para request de creacion y modificacion de administradores uby.
    public class UbyAdminRequest
    {
        public string CedulaAdminUby { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string PrimerApellido { get; set; } = null!;
        public string SegundoApellido { get; set; } = null!;
        public string CorreoElectronico { get; set; } = null!;
        public string UsuarioAdminUby { get; set; } = null!;
        public string PasswordAdminUby { get; set; } = null!;
        public string Provincia { get; set; } = null!;
        public string Canton { get; set; } = null!;
        public string Distrito { get; set; } = null!;
        public List<string> Telefonos {get; set; } = null!;
    }
}