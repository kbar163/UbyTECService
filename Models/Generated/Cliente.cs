using System;
using System.Collections.Generic;

namespace UbyTECService.Models.Generated
{
    public partial class Cliente
    {
        public Cliente()
        {
            ClienteTelefonos = new HashSet<ClienteTelefono>();
        }

        public string CedulaCliente { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string PrimerApellido { get; set; } = null!;
        public string SegundoApellido { get; set; } = null!;
        public DateTime FechaNacimiento { get; set; }
        public string CorreoElectronico { get; set; } = null!;
        public string UsuarioCliente { get; set; } = null!;
        public string PasswordCliente { get; set; } = null!;
        public string Provincia { get; set; } = null!;
        public string Canton { get; set; } = null!;
        public string Distrito { get; set; } = null!;

        public virtual ICollection<ClienteTelefono> ClienteTelefonos { get; set; }
    }
}
