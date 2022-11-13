using System;
using System.Collections.Generic;

namespace UbyTECService.Models.Generated
{
    public partial class PedidoProducto
    {
        public int IdLinea { get; set; }
        public int IdPedido { get; set; }
        public int IdProducto { get; set; }

        public virtual Pedido IdPedidoNavigation { get; set; } = null!;
        public virtual Producto IdProductoNavigation { get; set; } = null!;
    }
}
