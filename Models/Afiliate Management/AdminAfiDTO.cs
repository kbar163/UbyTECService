namespace UbyTECService.Models.AfiliateManagement
{
    public class AdminAfiDTO
    {
        public string Nombre { get; set; } = null!;
        public string PrimerApellido { get; set; } = null!;
        public string SegundoApellido { get; set; } = null!;
        public string CorreoElectronico { get; set; } = null!;
        public string UsuarioAdminAfi { get; set; } = null!;
        public string PasswordAdminAfi { get; set; } = null!;
        public string Provincia { get; set; } = null!;
        public string Canton { get; set; } = null!;
        public string Distrito { get; set; } = null!;
        public bool Activo { get; set; }
        public List<string> Telefonos { get; set; } = null!;
    }
}