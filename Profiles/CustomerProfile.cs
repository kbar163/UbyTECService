using AutoMapper;
using UbyTECService.Models.CustomerManagement;
using UbyTECService.Models.Generated;

namespace UbyTECService.Profiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Cliente,CustomerRequest>();
        }
    }
}