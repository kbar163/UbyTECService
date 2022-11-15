namespace UbyTECService.Models.OrderManagement
{
    public class OrderDTO
    {
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
        public List<OrderProduct> ProductosPedido {get; set; } = null!;
    }
}