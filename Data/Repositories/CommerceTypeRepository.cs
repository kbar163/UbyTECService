using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UbyTECService.Data.Context;
using UbyTECService.Data.Interfaces;
using UbyTECService.Models;
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

        public ActionResponse AddCommerceType(CommerceTypeRequest newCommerce)
        {
            var response = new ActionResponse();

             try
            {
                var addProduct = _context.Database.ExecuteSqlRaw("INSERT INTO TIPO_COMERCIO VALUES (DEFAULT,{0});",
                    newCommerce.Nombre);
                    response.actualizado = true;
                    response.mensaje = "Tipo de comercio creado exitosamente";

            }
            catch(Exception e)
            {
                response.actualizado = false;
                response.mensaje = "Error al crear tipo de comercio";
            }

            return response;
        }

        public ActionResponse DeleteCommereceType(NumIdRequest delCommerce)
        {
            var response = new ActionResponse();
            try
            {
                var deletion = _context.Database.ExecuteSqlRaw("DELETE FROM TIPO_COMERCIO WHERE ID_TIPO = {0};",delCommerce.id);
                response.actualizado = true;
                response.mensaje = "Tipo de comercio eliminado exitosamente";
            }
            catch
            {
                response.mensaje = "Error al eliminar tipo de comercio";
            }
            return response;
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

        public ActionResponse ModifyCommerceType(ModCommerceRequest newCommerce)
        {
            var response = new ActionResponse();

             try
            {
                var addProduct = _context.Database.ExecuteSqlRaw("UPDATE TIPO_COMERCIO SET NOMBRE_TIPO = {0} WHERE ID_TIPO = {1};",
                    newCommerce.Nombre,newCommerce.Id);
                    response.actualizado = true;
                    response.mensaje = "Tipo de comercio actualizado exitosamente";

            }
            catch(Exception e)
            {
                response.actualizado = false;
                response.mensaje = "Error al actualizar tipo de comercio";
            }

            return response;
        }
    }
}
