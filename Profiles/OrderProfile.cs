using AutoMapper;
using UbyTECService.Models.Generated;
using UbyTECService.Models.OrderManagement;

namespace UbyTECService.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Pedido,OrderDTO>();
        }
    }
}