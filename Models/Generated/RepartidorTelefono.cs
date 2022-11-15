using System;
using System.Collections.Generic;

namespace UbyTECService.Models.Generated
{
    public partial class RepartidorTelefono
    {
        public int IdLinea { get; set; }
        public string? UsuarioRepart { get; set; }
        public string? TelefonoRepart { get; set; }

        public virtual Repartidor? UsuarioRepartNavigation { get; set; }
    }
}
