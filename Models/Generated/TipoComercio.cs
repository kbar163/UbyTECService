using System;
using System.Collections.Generic;

namespace UbyTECService.Models.Generated
{
    public partial class TipoComercio
    {
        public TipoComercio()
        {
            Afiliados = new HashSet<Afiliado>();
        }

        public int IdTipo { get; set; }
        public string NombreTipo { get; set; } = null!;

        public virtual ICollection<Afiliado> Afiliados { get; set; }
    }
}
