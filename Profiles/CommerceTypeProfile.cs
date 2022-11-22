using AutoMapper;
using UbyTECService.Models.CommerceTypeManagement;
using UbyTECService.Models.Generated;

namespace UbyTECService.Profiles
{
    public class CommerceTypeProfile : Profile
    {
        public CommerceTypeProfile()
        {
            CreateMap<TipoComercio,CommerceType>();
        }
    }
}