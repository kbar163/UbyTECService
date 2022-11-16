namespace UbyTECService.Models.AfiliateManagement
{
    //DTO utilizado para respuesta al request de obtener un afiliado por un id dado.
    public class SingleAfiliate
    {
        public bool exito { get; set; }
        public AfiliateData afiliado { get; set; } = null!;
        
    }
}