using System;
using System.Collections.Generic;

namespace UbyTECService.Models.Generated
{
    public partial class Repartidor
    {
        public Repartidor()
        {
            Pedidos = new HashSet<Pedido>();
        }

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

        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}
