using System;
using System.Collections.Generic;

namespace UbyTECService.Models.Generated
{
    public partial class AfiliadoTelefono
    {
        public int Id { get; set; }
        public string? CedulaJuridica { get; set; }
        public string? Telefono { get; set; }

        public virtual Afiliado? CedulaJuridicaNavigation { get; set; }
    }
}
