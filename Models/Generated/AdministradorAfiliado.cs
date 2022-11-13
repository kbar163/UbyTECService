using System;
using System.Collections.Generic;

namespace UbyTECService.Models.Generated
{
    public partial class AdministradorAfiliado
    {
        public AdministradorAfiliado()
        {
            AdminAfiTelefonos = new HashSet<AdminAfiTelefono>();
        }

        public string Nombre { get; set; } = null!;
        public string PrimerApellido { get; set; } = null!;
        public string SegundoApellido { get; set; } = null!;
        public string CorreoElectronico { get; set; } = null!;
        public string UsuarioAdminAfi { get; set; } = null!;
        public string PasswordAdminAfi { get; set; } = null!;
        public string Provincia { get; set; } = null!;
        public string Canton { get; set; } = null!;
        public string Distrito { get; set; } = null!;
        public bool Activo { get; set; }

        public virtual AfiliadoAdmin AfiliadoAdmin { get; set; } = null!;
        public virtual ICollection<AdminAfiTelefono> AdminAfiTelefonos { get; set; }
    }
}
