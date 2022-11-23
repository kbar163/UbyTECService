namespace UbyTECService.Models.OrderManagement
{
    //Modelo de datos utilizado para hacer un request para recepcion de pedido al backend.
    public class AssignOrder
    {
       
        public int Id { get; set; }
        public string Provincia { get; set; } = null!;
        public string Canton { get; set; } = null!;
        public string Distrito { get; set; } = null!;
    
    }
}