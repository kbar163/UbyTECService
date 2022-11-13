using System;
using System.Collections.Generic;

namespace UbyTECService.Models.Generated
{
    public partial class Producto
    {
        public Producto()
        {
            PedidoProductos = new HashSet<PedidoProducto>();
        }

        public int IdProducto { get; set; }
        public string NombreProducto { get; set; } = null!;
        public string UrlFoto { get; set; } = null!;
        public int Precio { get; set; }
        public string CedulaJuridica { get; set; } = null!;
        public int IdCategoria { get; set; }

        public virtual Afiliado CedulaJuridicaNavigation { get; set; } = null!;
        public virtual Categorium IdCategoriaNavigation { get; set; } = null!;
        public virtual ICollection<PedidoProducto> PedidoProductos { get; set; }
    }
}
