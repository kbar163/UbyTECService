using System;
using System.Collections.Generic;

namespace UbyTECService.Models.Generated
{
    public partial class AdminAfiTelefono
    {
        public int Id { get; set; }
        public string? UsuarioAdminAfi { get; set; }
        public string? Telefono { get; set; }

        public virtual AdministradorAfiliado? UsuarioAdminAfiNavigation { get; set; }
    }
}
