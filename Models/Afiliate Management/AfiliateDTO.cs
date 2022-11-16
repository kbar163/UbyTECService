namespace UbyTECService.Models.AfiliateManagement
{
    public class AfiliateDTO
    {
        public string CedulaJuridica { get; set; } = null!;
        public string NombreComercio { get; set; } = null!;
        public string SinpeMovil { get; set; } = null!;
        public string Correo { get; set; } = null!;
        public string Provincia { get; set; } = null!;
        public string Canton { get; set; } = null!;
        public string Distrito { get; set; } = null!;
        public string? ComentarioSolicitud { get; set; }
        public bool Activo { get; set; }
        public int Tipo { get; set; }
        public List<string> Telefonos { get; set; } = null!;
    }
}