using AutoMapper;
using UbyTECService.Models.Generated;
using UbyTECService.Models.ProductManagement;

namespace UbyTECService.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Categorium,Category>();
        }
    }
}