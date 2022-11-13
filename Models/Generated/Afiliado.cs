using System;
using System.Collections.Generic;

namespace UbyTECService.Models.Generated
{
    public partial class Afiliado
    {
        public Afiliado()
        {
            AfiliadoAdmins = new HashSet<AfiliadoAdmin>();
            AfiliadoTelefonos = new HashSet<AfiliadoTelefono>();
            Pedidos = new HashSet<Pedido>();
            Productos = new HashSet<Producto>();
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
        public virtual ICollection<AfiliadoAdmin> AfiliadoAdmins { get; set; }
        public virtual ICollection<AfiliadoTelefono> AfiliadoTelefonos { get; set; }
        public virtual ICollection<Pedido> Pedidos { get; set; }
        public virtual ICollection<Producto> Productos { get; set; }
    }
}
