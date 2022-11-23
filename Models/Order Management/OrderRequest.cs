namespace UbyTECService.Models.OrderManagement
{
    public class OrderRequest
    {
       
        public string CedulaCliente { get; set; } = null!;
        public string CedulaJuridica { get; set; } = null!;
        public string Provincia { get; set; } = null!;
        public string Canton { get; set; } = null!;
        public string Distrito { get; set; } = null!;
        public DateTime Fecha { get; set; }
        public List<OrderRequestProduct> Productos {get; set; } = null!;
    }
}