using System;
using System.Collections.Generic;

namespace UbyTECService.Models.Generated
{
    public partial class AfiliadoAdmin
    {
        public string CedulaJuridica { get; set; } = null!;
        public string UsuarioAdminAfi { get; set; } = null!;
        public bool Activo { get; set; }

        public virtual Afiliado CedulaJuridicaNavigation { get; set; } = null!;
        public virtual AdministradorAfiliado UsuarioAdminAfiNavigation { get; set; } = null!;
    }
}
