using System;
using System.Collections.Generic;

namespace UbyTECService.Models.Generated
{
    public partial class ClienteTelefono
    {
        public int Id { get; set; }
        public string? CedulaCliente { get; set; }
        public string? Telefono { get; set; }

        public virtual Cliente? CedulaClienteNavigation { get; set; }
    }
}
