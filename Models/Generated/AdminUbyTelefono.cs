using System;
using System.Collections.Generic;

namespace UbyTECService.Models.Generated
{
    public partial class AdminUbyTelefono
    {
        public int Id { get; set; }
        public string? CedulaAdminUby { get; set; }
        public string? Telefono { get; set; }

        public virtual AdministradorUby? CedulaAdminUbyNavigation { get; set; }
    }
}
