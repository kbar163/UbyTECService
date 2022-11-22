using AutoMapper;
using UbyTECService.Data.Context;
using UbyTECService.Data.Interfaces;
using UbyTECService.Models.CommerceTypeManagement;
using UbyTECService.Models.Generated;

namespace UbyTECService.Data.Repositories
{
    public class CommerceTypeRepository : ICommerceTypeRepository
    {
        private readonly ubytecdbContext _context;
        private readonly IMapper _mapper;

        public CommerceTypeRepository(ubytecdbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public MultiCommerceType GetAllCommerceTypes()
        {
            var response = new MultiCommerceType();
            try
            {
                var tipos = _context.TipoComercios.ToList();
                var commerceDTO = _mapper.Map<List<CommerceType>>(tipos);

                if (tipos.Count != 0)
                {
                    response.tipos = commerceDTO;
                    response.exito = true;
                }
                else
                {
                    response.exito = false;
                }
            }
            catch (Exception e)
            {
                response.exito = false;
            }

            return response;
        }

    }
}
