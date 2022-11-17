namespace UbyTECService.Models.AfiliateManagement
{
    //DTO utilizado para respuesta al request de obtener todos los afiliados.
    public class MultiAfiliate
    {
        public bool exito { get; set; }
        public List<AfiliateData> afiliados { get; set; } = null!;
        
    }
}