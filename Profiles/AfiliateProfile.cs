using AutoMapper;
using UbyTECService.Models.AfiliateManagement;
using UbyTECService.Models.Generated;

namespace UbyTECService.Profiles
{
    public class AfiliateProfile : Profile
    {
        public AfiliateProfile()
        {
            CreateMap<Afiliado,AfiliateDTO>();
        }
    }
}