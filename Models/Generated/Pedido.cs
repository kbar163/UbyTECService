using System;
using System.Collections.Generic;

namespace UbyTECService.Models.Generated
{
    public partial class Pedido
    {
        public Pedido()
        {
            PedidoProductos = new HashSet<PedidoProducto>();
        }

        public int IdPedido { get; set; }
        public int Monto { get; set; }
        public int IdEstado { get; set; }
        public string CedulaCliente { get; set; } = null!;
        public string Provincia { get; set; } = null!;
        public string Canton { get; set; } = null!;
        public string Distrito { get; set; } = null!;
        public string CedulaJuridica { get; set; } = null!;
        public DateTime FechaPedido { get; set; }
        public string UsuarioRepart { get; set; } = null!;

        public virtual Cliente CedulaClienteNavigation { get; set; } = null!;
        public virtual Afiliado CedulaJuridicaNavigation { get; set; } = null!;
        public virtual Estado IdEstadoNavigation { get; set; } = null!;
        public virtual Repartidor UsuarioRepartNavigation { get; set; } = null!;
        public virtual ICollection<PedidoProducto> PedidoProductos { get; set; }
    }
}
