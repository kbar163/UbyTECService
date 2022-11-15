using AutoMapper;
using UbyTECService.Models.Generated;
using UbyTECService.Models.ProductManagement;

namespace UbyTECService.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Producto,ProductDTO>();
        }
    }
}