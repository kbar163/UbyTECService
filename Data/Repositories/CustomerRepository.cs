using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UbyTECService.Data.Context;
using UbyTECService.Data.Interfaces;
using UbyTECService.Models;
using UbyTECService.Models.CustomerManagement;
using UbyTECService.Models.Generated;

namespace UbyTECService.Data.Repositories
{
    //Implementacion de la logica para cada una de los endpoints expuesos en CustomerController,
    //esta clase extiende la interfaz ICustomerRepository, e implementa los metodos relacionados
    //a la manipulacion de datos necesaria para cumplir con los requerimientos funcionales
    //de la aplicacion.
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ubytecdbContext _context;
        private readonly IMapper _mapper;

        public CustomerRepository(ubytecdbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //Entrada: CustomerRequest newCustomer; Continene los datos necesarios para crear un nuevo cliente en la base de datos
        //Proceso: Revisa la cantidad de numeros de telefono que el usuario quiere agregar y acorde a esto ejecuta el procedimiento
        //almacenado correspondiente para crear un cliente en la base de datos.
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

        //Entrada: IdRequest delCustomer; Continene el id de  un cliente a eliminar en la base de datos
        //Proceso: Ejecuta el query de borrar haciendo uso del id, lo cual dispara un trigger que elimina todos los datos
        //relacionados al cliente en cascada.
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

        //Entrada: string id que representa el usuario de un cliente
        //Proceso: Haciendo uso de EntityFramework.Core, obtiene un cliente registrado en la base de datos basado en el id.
        //Salida: SingleCustomer response; Contiene una propiedad booleana "exito" que indica si la operacion fue exitosa, y un
        //Repartidor que representa el dato del customer con el usuario que hace match con la entrada id.
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

        //Entrada: CustomerRequest modCustomer; Continene los datos necesarios para modificar un cliente en la base de datos
        //Proceso: Revisa la cantidad de numeros de telefono que el usuario quiere modificar y acorde a esto ejecuta el procedimiento
        //almacenado correspondiente para modificar un cliente en la base de datos.
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
