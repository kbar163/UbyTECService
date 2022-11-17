namespace UbyTECService.Models.ProductManagement
{
    public partial class ProductRequest
    {

        public int IdProducto { get; set; }   
        public string CedulaJuridica { get; set; } = null!;    
        public string NombreProducto { get; set; } = null!;
        public string UrlFoto { get; set; } = null!;
        public int Precio { get; set; }
        public int IdCategoria { get; set; }

    }
}