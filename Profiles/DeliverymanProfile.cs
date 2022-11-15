using AutoMapper;
using UbyTECService.Models.DeliveryManagement;
using UbyTECService.Models.Generated;

namespace UbyTECService.Profiles
{
    public class DeliverymanProfile : Profile
    {
        public DeliverymanProfile()
        {
            CreateMap<Repartidor,DeliverymanDTO>();
        }
    }
}