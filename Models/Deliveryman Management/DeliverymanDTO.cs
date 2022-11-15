namespace UbyTECService.Models.DeliveryManagement
{
    public partial class DeliverymanDTO
    {

        public string UsuarioRepart { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string PrimerApellido { get; set; } = null!;
        public string SegundoApellido { get; set; } = null!;
        public string CorreoRepart { get; set; } = null!;
        public string PasswordRepart { get; set; } = null!;
        public string Provincia { get; set; } = null!;
        public string Canton { get; set; } = null!;
        public string Distrito { get; set; } = null!;
        public bool Disponible { get; set; }
        public List<string> Telefonos {get; set; } = null!;
    }
}