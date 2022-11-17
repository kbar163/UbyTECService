using AutoMapper;
using UbyTECService.Models.AfiliateManagement;
using UbyTECService.Models.Generated;

namespace UbyTECService.Profiles
{
    public class AdminAfiProfile : Profile
    {
        public AdminAfiProfile()
        {
            CreateMap<AdministradorAfiliado,AdminAfiDTO>();
        }
    }
}