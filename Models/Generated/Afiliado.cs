using System;
using System.Collections.Generic;

namespace UbyTECService.Models.Generated
{
    public partial class Afiliado
    {
        public Afiliado()
        {
            AfiliadoTelefonos = new HashSet<AfiliadoTelefono>();
        }

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

        public virtual TipoComercio TipoNavigation { get; set; } = null!;
        public virtual ICollection<AfiliadoTelefono> AfiliadoTelefonos { get; set; }
    }
}
