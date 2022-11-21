using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UbyTECService.Data.Context;
using UbyTECService.Data.Interfaces;
using UbyTECService.Models;
using UbyTECService.Models.CustomerManagement;
using UbyTECService.Models.Generated;

namespace UbyTECService.Data.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ubytecdbContext _context;
        private readonly IMapper _mapper;

        public CustomerRepository(ubytecdbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ActionResponse AddCustomer(CustomerRequest newCustomer)
        {
            var response = new ActionResponse();

            try
            {

                if (newCustomer.Telefonos.Count > 1)
                {

                    var addCustomer = _context.Database.ExecuteSqlRaw("CALL ADD_CLIENTE({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12});",
                    newCustomer.CedulaCliente, newCustomer.Nombre, newCustomer.PrimerApellido, newCustomer.SegundoApellido, newCustomer.FechaNacimiento.ToUniversalTime(),
                    newCustomer.CorreoElectronico, newCustomer.UsuarioCliente, newCustomer.PasswordCliente, newCustomer.Provincia,
                    newCustomer.Canton, newCustomer.Distrito, newCustomer.Telefonos[0], newCustomer.Telefonos[1]);
                    response.actualizado = true;
                    response.mensaje = "Cliente creado exitosamente";

                }
                else
                {
                    var addCustomer = _context.Database.ExecuteSqlRaw("CALL ADD_CLIENTE({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11});",
                    newCustomer.CedulaCliente, newCustomer.Nombre, newCustomer.PrimerApellido, newCustomer.SegundoApellido, newCustomer.FechaNacimiento,
                    newCustomer.CorreoElectronico, newCustomer.UsuarioCliente, newCustomer.PasswordCliente, newCustomer.Provincia,
                    newCustomer.Canton, newCustomer.Distrito, newCustomer.Telefonos[0]);
                    response.actualizado = true;
                    response.mensaje = "Cliente creado exitosamente";
                }
            }
            catch (Exception e)
            {
                response.actualizado = false;
                response.mensaje = "Error al crear el cliente";
                Console.WriteLine(e.Message);
            }

            return response;
        }

        public ActionResponse DeleteCustomer(IdRequest delCustomer)
        {
            var response = new ActionResponse();
            try
            {
                var removeCustomer = _context.Database.ExecuteSqlRaw("DELETE FROM CLIENTE WHERE CEDULA_CLIENTE = {0};",delCustomer.id);
                response.actualizado = true;
                response.mensaje = "Cliente eliminado exitosamente";
            }
            catch(Exception e)
            {
                response.actualizado = false;
                response.mensaje = "Error al eleminar cliente";
                Console.WriteLine(e.Message);
            }
            return response;
        }

        public SingleCustomer GetCustomerById(string id)
        {
            var response = new SingleCustomer();
            try
            {
                var customer = _context.Clientes
                .Include(r => r.ClienteTelefonos)
                .Where(r => r.CedulaCliente == id)
                .FirstOrDefault<Cliente>();

                if(customer != null)
                {
                    var customerDTO = _mapper.Map<CustomerRequest>(customer);
                    customerDTO.Telefonos = new List<string>();
                    foreach(ClienteTelefono element in customer.ClienteTelefonos.ToList())
                    {
                        customerDTO.Telefonos.Add(element.Telefono);
                    }
                    response.exito = true;
                    response.customer = customerDTO;
                }
                else
                {
                    response.exito = false;
                }
            }
            catch(Exception e)
            {
                response.exito = false;
                Console.WriteLine(e.Message);
            }
            
            return response;
        }

        public ActionResponse ModifyCustomer(CustomerRequest modCustomer)
        {
            var response = new ActionResponse();

            try
            {

                if (modCustomer.Telefonos.Count > 1)
                {

                    var modifyCustomer = _context.Database.ExecuteSqlRaw("CALL UPDATE_CLIENTE({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12});",
                    modCustomer.CedulaCliente, modCustomer.Nombre, modCustomer.PrimerApellido, modCustomer.SegundoApellido, modCustomer.FechaNacimiento.ToUniversalTime(),
                    modCustomer.CorreoElectronico, modCustomer.UsuarioCliente, modCustomer.PasswordCliente, modCustomer.Provincia,
                    modCustomer.Canton, modCustomer.Distrito, modCustomer.Telefonos[0], modCustomer.Telefonos[1]);
                    response.actualizado = true;
                    response.mensaje = "Cliente actualizado exitosamente";

                }
                else
                {
                    var modifyCustomer = _context.Database.ExecuteSqlRaw("CALL UPDATE_CLIENTE({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11});",
                    modCustomer.CedulaCliente, modCustomer.Nombre, modCustomer.PrimerApellido, modCustomer.SegundoApellido, modCustomer.FechaNacimiento.ToUniversalTime(),
                    modCustomer.CorreoElectronico, modCustomer.UsuarioCliente, modCustomer.PasswordCliente, modCustomer.Provincia,
                    modCustomer.Canton, modCustomer.Distrito, modCustomer.Telefonos[0]);
                    response.actualizado = true;
                    response.mensaje = "Cliente actualizado exitosamente";
                }
            }
            catch (Exception e)
            {
                response.actualizado = false;
                response.mensaje = "Error al actualizar el cliente";
                Console.WriteLine(e.Message);
            }

            return response;
        }
    }
}
