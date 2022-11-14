using UbyTECService.Data.Context;
using Microsoft.EntityFrameworkCore;
using UbyTECService.Data.Interfaces;
using UbyTECService.Models;
using UbyTECService.Models.UbyAdminManagement;
using UbyTECService.Models.Generated;

namespace UbyTECService.Data.Repositories
{
    //Implementacion de la logica para cada una de los endpoints expuesos en LoginController,
    //esta clase extiende la interfaz ILoginRepository, e implementa los metodos relacionados
    //a la manipulacion de datos necesaria para cumplir con los requerimientos funcionales
    //de la aplicacion.
    public class UbyAdminRepository : IUbyAdminRepository
    {
        private readonly ubytecdbContext _context;

        public UbyAdminRepository(ubytecdbContext context)
        {
            _context = context;
        }

        //Entrada: UbyAdminRequest newAdmin; Continene los datos necesarios para crear un nuevo administrador en la base de datos
        //Proceso: Revisa la cantidad de numeros de telefono que el usuario quiere agregar y acorde a esto ejecuta el procedimiento
        //almacenado correspondiente para crear un administrador en la base de datos.
        public ActionResponse AddUbyAdmin(UbyAdminRequest newAdmin)
        {
            var response = new ActionResponse();

            try
            {
                if(newAdmin.Telefonos.Count > 1)
                {
                    var addAdmin = _context.Database.ExecuteSqlRaw("CALL ADD_UBY_ADMIN({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11});",
                    newAdmin.CedulaAdminUby,newAdmin.Nombre,newAdmin.PrimerApellido,newAdmin.SegundoApellido,
                    newAdmin.CorreoElectronico,newAdmin.UsuarioAdminUby,newAdmin.PasswordAdminUby,newAdmin.Provincia,
                    newAdmin.Canton,newAdmin.Distrito,newAdmin.Telefonos[0],newAdmin.Telefonos[1]);
                    response.actualizado = true;
                    response.mensaje = "Administrador Uby creado exitosamente";
                }
                else
                {
                    var addAdmin = _context.Database.ExecuteSqlRaw("CALL ADD_UBY_ADMIN({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10});",
                    newAdmin.CedulaAdminUby,newAdmin.Nombre,newAdmin.PrimerApellido,newAdmin.SegundoApellido,
                    newAdmin.CorreoElectronico,newAdmin.UsuarioAdminUby,newAdmin.PasswordAdminUby,newAdmin.Provincia,
                    newAdmin.Canton,newAdmin.Distrito,newAdmin.Telefonos[0]);
                    response.actualizado = true;
                    response.mensaje = "Administrador Uby creado exitosamente";
                }
            }
            catch(Exception e)
            {
                response.actualizado = false;
                response.mensaje = e.Message;
            }
            
            return response;
        }

        //Entrada: DeleteUbyAdminRequest delAdmin; Continene el id de  un administrador a eliminar en la base de datos
        //Proceso: Ejecuta el query de borrar haciendo uso del id, lo cual dispara un trigger que elimina todos los datos
        //relacionados al administrador en cascada.
        public ActionResponse DeleteUbyAdmin(DeleteUbyAdminRequest delAdmin)
        {
            var response = new ActionResponse();
            try
            {
                var removeAdmin = _context.Database.ExecuteSqlRaw("DELETE FROM ADMINISTRADOR_UBY WHERE CEDULA_ADMIN_UBY = {0};",delAdmin.CedulaAdminUby);
                response.actualizado = true;
                response.mensaje = "Administrador Uby eliminado exitosamente";
            }
            catch(Exception e)
            {
                response.actualizado = false;
                response.mensaje = e.Message;
            }
            return response;
        }

        //Proceso: Haciendo uso de EntityFramework.Core, obtiene todos los administradores uby registrados en la base de datos.
        //Salida MultiUbyAdmin response; Contiene una propiedad booleana "exito" que indica si la operacion fue exitosa, y una propiedad lista
        //de AdministradorUby poblada con los objetos que representan los datos existentes en la base de datos.
        public MultiUbyAdmin GetAllUbyAdmin()
        {
            var response = new MultiUbyAdmin();
            try
            {
                var admin = _context.AdministradorUbies.Include(a => a.AdminUbyTelefonos).ToList(); 
                if(admin.Count != 0)
                {
                    response.exito = true;
                    response.admin = admin;
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

        //Entrada: string id que representa la cedula de un administrador de uby
        //Proceso: Haciendo uso de EntityFramework.Core, obtiene un administrador uby registrado en la base de datos basado en el id.
        //Salida: SingleUbyAdmin response; Contiene una propiedad booleana "exito" que indica si la operacion fue exitosa, y un
        //AdministradorUby que representa el dato del administrador con la cedula que hace match con la entrada id.
        public SingleUbyAdmin GetUbyAdminById(string id)
        {
            var response = new SingleUbyAdmin();
            try
            {
                var admin = _context.AdministradorUbies.Include(a => a.AdminUbyTelefonos)
                            .Where(a => a.CedulaAdminUby == id)
                            .FirstOrDefault<AdministradorUby>(); 
                if(admin != null)
                {
                    response.exito = true;
                    response.admin = admin;
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

        //Entrada: UbyAdminRequest modAdmin; Continene los datos necesarios para modificar un administrador en la base de datos
        //Proceso: Revisa la cantidad de numeros de telefono que el usuario quiere modificar y acorde a esto ejecuta el procedimiento
        //almacenado correspondiente para actualizar un administrador en la base de datos.
        public ActionResponse ModifyUbyAdmin(UbyAdminRequest modAdmin)
        {
            var response = new ActionResponse();

            try
            {
                if(modAdmin.Telefonos.Count > 1)
                {
                    var addAdmin = _context.Database.ExecuteSqlRaw("CALL UPDATE_UBY_ADMIN({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11});",
                    modAdmin.CedulaAdminUby,modAdmin.Nombre,modAdmin.PrimerApellido,modAdmin.SegundoApellido,
                    modAdmin.CorreoElectronico,modAdmin.UsuarioAdminUby,modAdmin.PasswordAdminUby,modAdmin.Provincia,
                    modAdmin.Canton,modAdmin.Distrito,modAdmin.Telefonos[0],modAdmin.Telefonos[1]);
                    response.actualizado = true;
                    response.mensaje = "Administrador Uby actualizado exitosamente";
                }
                else
                {
                    var addAdmin = _context.Database.ExecuteSqlRaw("CALL UPDATE_UBY_ADMIN({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10});",
                    modAdmin.CedulaAdminUby,modAdmin.Nombre,modAdmin.PrimerApellido,modAdmin.SegundoApellido,
                    modAdmin.CorreoElectronico,modAdmin.UsuarioAdminUby,modAdmin.PasswordAdminUby,modAdmin.Provincia,
                    modAdmin.Canton,modAdmin.Distrito,modAdmin.Telefonos[0]);
                    response.actualizado = true;
                    response.mensaje = "Administrador Uby actualizado exitosamente";
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