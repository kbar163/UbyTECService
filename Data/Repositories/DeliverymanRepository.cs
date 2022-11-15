using UbyTECService.Data.Context;
using Microsoft.EntityFrameworkCore;
using UbyTECService.Data.Interfaces;
using UbyTECService.Models;
using UbyTECService.Models.UbyAdminManagement;
using UbyTECService.Models.Generated;
using UbyTECService.Models.DeliveryManagement;
using AutoMapper;

namespace UbyTECService.Data.Repositories
{
    //Implementacion de la logica para cada una de los endpoints expuesos en LoginController,
    //esta clase extiende la interfaz ILoginRepository, e implementa los metodos relacionados
    //a la manipulacion de datos necesaria para cumplir con los requerimientos funcionales
    //de la aplicacion.
    public class DeliverymanRepository : IDeliverymanRepository
    {
        private readonly ubytecdbContext _context;
        private readonly IMapper _mapper;

        public DeliverymanRepository(ubytecdbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //Entrada: DeliverymanRequest newDeliveryman; Continene los datos necesarios para crear un nuevo repartidor en la base de datos
        //Proceso: Revisa la cantidad de numeros de telefono que el usuario quiere agregar y acorde a esto ejecuta el procedimiento
        //almacenado correspondiente para crear un repartidor en la base de datos.
        public ActionResponse AddDeliveryman(DeliverymanRequest newDeliveryman)
        {
            var response = new ActionResponse();

            try
            {
                if(newDeliveryman.Telefonos.Count > 1)
                {
                    
                    var addDeliveryman = _context.Database.ExecuteSqlRaw("CALL ADD_REPARTIDOR({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11});",
                    newDeliveryman.UsuarioRepart,newDeliveryman.Nombre,newDeliveryman.PrimerApellido,newDeliveryman.SegundoApellido,
                    newDeliveryman.CorreoRepart,newDeliveryman.PasswordRepart,newDeliveryman.Provincia,
                    newDeliveryman.Canton,newDeliveryman.Distrito,newDeliveryman.Telefonos[0],newDeliveryman.Telefonos[1],newDeliveryman.Disponible);
                    response.actualizado = true;
                    response.mensaje = "Repartidor creado exitosamente";
                    
                }
                else
                {
                    var addDeliveryman = _context.Database.ExecuteSqlRaw("CALL ADD_REPARTIDOR({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10});",
                    newDeliveryman.UsuarioRepart,newDeliveryman.Nombre,newDeliveryman.PrimerApellido,newDeliveryman.SegundoApellido,
                    newDeliveryman.CorreoRepart,newDeliveryman.PasswordRepart,newDeliveryman.Provincia,
                    newDeliveryman.Canton,newDeliveryman.Distrito,newDeliveryman.Telefonos[0],newDeliveryman.Disponible);
                    response.actualizado = true;
                    response.mensaje = "Repartidor creado exitosamente";
                }
            }
            catch(Exception e)
            {
                response.actualizado = false;
                response.mensaje = e.Message;
            }
            
            return response;
        }


        //Entrada: IdRequest delDeliveryman; Continene el id de  un repartidor a eliminar en la base de datos
        //Proceso: Ejecuta el query de borrar haciendo uso del id, lo cual dispara un trigger que elimina todos los datos
        //relacionados al repartidor en cascada.
        public ActionResponse DeleteDeliveryman(IdRequest delDeliveryman)
        {
            var response = new ActionResponse();
            try
            {
                var removeDeliveryman = _context.Database.ExecuteSqlRaw("DELETE FROM REPARTIDOR WHERE USUARIO_REPART = {0};",delDeliveryman.id);
                response.actualizado = true;
                response.mensaje = "Repartidor eliminado exitosamente";
            }
            catch(Exception e)
            {
                response.actualizado = false;
                response.mensaje = "Error al eleminar repartidor";
            }
            return response;
        }

        //Proceso: Haciendo uso de EntityFramework.Core, obtiene todos los repartidores registrados en la base de datos.
        //Salida MultiDeliveryman response; Contiene una propiedad booleana "exito" que indica si la operacion fue exitosa, y una propiedad lista
        //de Repartidor poblada con los objetos que representan los datos existentes en la base de datos.
        public MultiDeliveryman GetAllDeliverymen()
        {
            var response = new MultiDeliveryman();
            try
            {
                var repartidores = _context.Repartidors
                .Include(r => r.RepartidorTelefonos).ToList();
                 
                if(repartidores.Count != 0)
                {
                    var repartidoresDTO = _mapper.Map<List<DeliverymanDTO>>(repartidores);

                    for(int i = 0; i < repartidoresDTO.Count; i++)
                    {
                        repartidoresDTO[i].Telefonos = new List<string>();
                        for(int j = 0; j < repartidores[i].RepartidorTelefonos.Count; j++)
                        {
                            repartidoresDTO[i].Telefonos.Add(repartidores[i].RepartidorTelefonos.ElementAt(j).TelefonoRepart);
                        }
                    }
                    response.exito = true;
                    response.repartidores = repartidoresDTO;
                }
                else
                {
                    response.exito = false;
                }
            }
            catch(Exception e)
            {
                response.exito = false;
            }
            
            return response;
        }

        //Entrada: string id que representa el usuario de un repartidor
        //Proceso: Haciendo uso de EntityFramework.Core, obtiene un repartidor registrado en la base de datos basado en el id.
        //Salida: SingleDeliveryman response; Contiene una propiedad booleana "exito" que indica si la operacion fue exitosa, y un
        //Repartidor que representa el dato del repartidor con el usuario que hace match con la entrada id.
        public SingleDeliveryman GetDeliverymanById(string id)
        {
            var response = new SingleDeliveryman();
            try
            {
                var repartidor = _context.Repartidors
                .Include(r => r.RepartidorTelefonos)
                .Where(r => r.UsuarioRepart == id)
                .FirstOrDefault<Repartidor>();

                if(repartidor != null)
                {
                    var repartidorDTO = _mapper.Map<DeliverymanDTO>(repartidor);
                    repartidorDTO.Telefonos = new List<string>();
                    foreach(RepartidorTelefono element in repartidor.RepartidorTelefonos.ToList())
                    {
                        repartidorDTO.Telefonos.Add(element.TelefonoRepart);
                    }
                    response.exito = true;
                    response.repartidor = repartidorDTO;
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

        //Entrada: DeliverymanRequest newDeliveryman; Continene los datos necesarios para modificar un repartidor en la base de datos
        //Proceso: Revisa la cantidad de numeros de telefono que el usuario quiere modificar y acorde a esto ejecuta el procedimiento
        //almacenado correspondiente para modificar un repartidor en la base de datos.
        public ActionResponse ModifyDeliveryman(DeliverymanRequest modDeliveryman)
        {
            var response = new ActionResponse();

            try
            {
                if(modDeliveryman.Telefonos.Count > 1)
                {
                    
                    var addDeliveryman = _context.Database.ExecuteSqlRaw("CALL UPDATE_REPARTIDOR({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11});",
                    modDeliveryman.UsuarioRepart,modDeliveryman.Nombre,modDeliveryman.PrimerApellido,modDeliveryman.SegundoApellido,
                    modDeliveryman.CorreoRepart,modDeliveryman.PasswordRepart,modDeliveryman.Provincia,
                    modDeliveryman.Canton,modDeliveryman.Distrito,modDeliveryman.Telefonos[0],modDeliveryman.Telefonos[1],modDeliveryman.Disponible);
                    response.actualizado = true;
                    response.mensaje = "Repartidor creado exitosamente";
                    
                }
                else
                {
                    var addDeliveryman = _context.Database.ExecuteSqlRaw("CALL UPDATE_REPARTIDOR({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10});",
                    modDeliveryman.UsuarioRepart,modDeliveryman.Nombre,modDeliveryman.PrimerApellido,modDeliveryman.SegundoApellido,
                    modDeliveryman.CorreoRepart,modDeliveryman.PasswordRepart,modDeliveryman.Provincia,
                    modDeliveryman.Canton,modDeliveryman.Distrito,modDeliveryman.Telefonos[0],modDeliveryman.Disponible);
                    response.actualizado = true;
                    response.mensaje = "Repartidor creado exitosamente";
                }
            }
            catch(Exception e)
            {
                response.actualizado = false;
                response.mensaje = e.Message;
            }
            
            return response;
        }

    }
}
