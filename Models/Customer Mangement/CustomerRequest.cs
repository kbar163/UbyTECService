namespace UbyTECService.Models.CustomerManagement
{
    //DTO utilizado para request de creacion y modificacion de clientes uby.
    public class CustomerRequest
    {
        public string CedulaCliente { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string PrimerApellido { get; set; } = null!;
        public string SegundoApellido { get; set; } = null!;
        public DateTime FechaNacimiento { get; set; }
        public string CorreoElectronico { get; set; } = null!;
        public string UsuarioCliente { get; set; }  = null!;
        public string PasswordCliente { get; set; } = null!;
        public string Provincia { get; set; } = null!;
        public string Canton { get; set; } = null!;
        public string Distrito { get; set; } = null!;
        public List<string> Telefonos {get; set; } = null!;
    }
}