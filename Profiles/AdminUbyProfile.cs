using AutoMapper;
using UbyTECService.Models.Generated;
using UbyTECService.Models.UbyAdminManagement;

namespace UbyTECService.Profiles
{
    public class AdminUbyProfile : Profile
    {
        public AdminUbyProfile()
        {
            CreateMap<AdministradorUby,AdminUbyDTO>();
        }
    }
}