namespace UbyTECService.Models.ProductManagement
{
    public partial class ProductDTO
    {
        
        public int IdProducto { get; set; }
        public string NombreProducto { get; set; } = null!;
        public string UrlFoto { get; set; } = null!;
        public int Precio { get; set; }
        public string CedulaJuridica { get; set; } = null!;
        public int IdCategoria { get; set; }
        public string NombreCategoria {get; set; } = null!;
    }
}