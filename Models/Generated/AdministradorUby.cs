using System;
using System.Collections.Generic;

namespace UbyTECService.Models.Generated
{
    public partial class AdministradorUby
    {
        public AdministradorUby()
        {
            AdminUbyTelefonos = new HashSet<AdminUbyTelefono>();
        }

        public string CedulaAdminUby { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string PrimerApellido { get; set; } = null!;
        public string SegundoApellido { get; set; } = null!;
        public string CorreoElectronico { get; set; } = null!;
        public string UsuarioAdminUby { get; set; } = null!;
        public string PasswordAdminUby { get; set; } = null!;
        public string Provincia { get; set; } = null!;
        public string Canton { get; set; } = null!;
        public string Distrito { get; set; } = null!;

        public virtual ICollection<AdminUbyTelefono> AdminUbyTelefonos { get; set; }
    }
}
