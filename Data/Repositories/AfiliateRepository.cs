using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UbyTECService.Data.Context;
using UbyTECService.Data.Interfaces;
using UbyTECService.Models;
using UbyTECService.Models.AfiliateManagement;
using UbyTECService.Models.Generated;

namespace UbyTECService.Data.Repositories
{
    public class AfiliateRepository : IAfiliateRepository
    {
        private readonly ubytecdbContext _context;
        private readonly IMapper _mapper;

        public AfiliateRepository(ubytecdbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ActionResponse AddAfiliate(AfiliateData newAfiliate)
        {
            var response = new ActionResponse();

            try
            {
                var commerce = newAfiliate.Comercio;
                var newAdmin = newAfiliate.Administrador;

                if(commerce.Telefonos.Count > 1)
                {
                    var addAfiliate = _context.Database.ExecuteSqlRaw("CALL ADD_AFILIADO({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11});",
                    commerce.CedulaJuridica,commerce.NombreComercio,commerce.SinpeMovil,commerce.Correo,
                    commerce.Provincia,commerce.Canton,commerce.Distrito,commerce.ComentarioSolicitud,
                    commerce.Activo,commerce.Tipo,commerce.Telefonos[0],commerce.Telefonos[1]);


                }
                else
                {
                    var addAfiliate = _context.Database.ExecuteSqlRaw("CALL ADD_AFILIADO({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10});",
                    commerce.CedulaJuridica,commerce.NombreComercio,commerce.SinpeMovil,commerce.Correo,
                    commerce.Provincia,commerce.Canton,commerce.Distrito,commerce.ComentarioSolicitud,
                    commerce.Activo,commerce.Tipo,commerce.Telefonos[0]);
                    response.actualizado = true;

                }

                if (newAdmin.Telefonos.Count > 1)
                {
                    var addAdmin = _context.Database.ExecuteSqlRaw("CALL ADD_AFI_ADMIN({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11});",
                    newAdmin.Nombre, newAdmin.PrimerApellido, newAdmin.SegundoApellido,
                    newAdmin.CorreoElectronico, newAdmin.UsuarioAdminAfi, newAdmin.PasswordAdminAfi, newAdmin.Provincia,
                    newAdmin.Canton, newAdmin.Distrito, newAdmin.Activo, newAdmin.Telefonos[0], newAdmin.Telefonos[1]);

                }
                else
                {
                    var addAdmin = _context.Database.ExecuteSqlRaw("CALL ADD_AFI_ADMIN({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10});",
                    newAdmin.Nombre, newAdmin.PrimerApellido, newAdmin.SegundoApellido,
                    newAdmin.CorreoElectronico, newAdmin.UsuarioAdminAfi, newAdmin.PasswordAdminAfi, newAdmin.Provincia,
                    newAdmin.Canton, newAdmin.Distrito, newAdmin.Activo, newAdmin.Telefonos[0]);
                }

                var relateEntities = _context.Database.ExecuteSqlRaw("CALL REL_AFI_ADMIN_AND_AFILIATE({0},{1});",
                commerce.CedulaJuridica,newAdmin.UsuarioAdminAfi);
                response.actualizado = true;
                response.mensaje = "Afiliado creado exitosamente";

            }
            catch(Exception e)
            {
                response.actualizado = false;
                response.mensaje = "Error al crear afiliado";
                Console.WriteLine(e.Message);
            }
            
            return response;
        }


        public SingleAfiliate GetAfiliateById(string id)
        {
            var response = new SingleAfiliate();
            try
            {
                var afiliate = _context.Afiliados
                .Include(a => a.AfiliadoAdmins)
                .Include(a => a.AfiliadoTelefonos)
                .Where(a => a.CedulaJuridica == id)
                .FirstOrDefault<Afiliado>();

                if (afiliate != null)
                {
                    var adminUser = afiliate.AfiliadoAdmins.ElementAt(0).UsuarioAdminAfi;
                    var admin = _context.AdministradorAfiliados
                    .Include(a => a.AdminAfiTelefonos)
                    .Where(a => a.UsuarioAdminAfi == adminUser)
                    .FirstOrDefault<AdministradorAfiliado>();

                    var afiliadoDTO = _mapper.Map<AfiliateDTO>(afiliate);
                    var adminDTO = _mapper.Map<AdminAfiDTO>(admin);
                    adminDTO.Telefonos = new List<string>();
                    afiliadoDTO.Telefonos = new List<string>();

                    foreach (AfiliadoTelefono element in afiliate.AfiliadoTelefonos)
                    {
                        afiliadoDTO.Telefonos.Add(element.Telefono);
                    }

                    foreach (AdminAfiTelefono element in admin.AdminAfiTelefonos)
                    {
                        adminDTO.Telefonos.Add(element.Telefono);
                    }
                    response.exito = true;
                    response.afiliado = new AfiliateData();
                    response.afiliado.Comercio = afiliadoDTO;
                    response.afiliado.Administrador = adminDTO;
                }
                else
                {
                    response.exito = false;
                }
            }
            catch (Exception e)
            {
                response.exito = false;
                Console.WriteLine(e.Message);
            }

            return response;
        }

        public MultiAfiliate GetAllAfiliates()
        {
            var response = new MultiAfiliate();
            try
            {
                var afiliates = _context.Afiliados
                .Include(a => a.AfiliadoAdmins)
                .Include(a => a.AfiliadoTelefonos)
                .ToList();

                if (afiliates.Count != 0)
                {
                    var afiliadosDTO = _mapper.Map<List<AfiliateDTO>>(afiliates);
                    response.afiliados = new List<AfiliateData>();

                    for (int i = 0; i < afiliadosDTO.Count; i++)
                    {
                        afiliadosDTO[i].Telefonos = new List<string>();
                        var adminUser = afiliates.ElementAt(i).AfiliadoAdmins.ElementAt(0).UsuarioAdminAfi;
                        var admin = _context.AdministradorAfiliados
                            .Include(a => a.AdminAfiTelefonos)
                            .Where(a => a.UsuarioAdminAfi == adminUser)
                            .FirstOrDefault<AdministradorAfiliado>();
                        var adminDTO = _mapper.Map<AdminAfiDTO>(admin);
                        adminDTO.Telefonos = new List<string>();

                        foreach (AfiliadoTelefono element in afiliates[i].AfiliadoTelefonos)
                        {
                            afiliadosDTO[i].Telefonos.Add(element.Telefono);
                        }

                        foreach (AdminAfiTelefono element in admin.AdminAfiTelefonos)
                        {
                            adminDTO.Telefonos.Add(element.Telefono);
                        }

                        var data = new AfiliateData();
                        data.Administrador = adminDTO;
                        data.Comercio = afiliadosDTO[i];
                        response.afiliados.Add(data);
                    }
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
                Console.WriteLine(e.Message);
            }

            return response;
        }

        public ActionResponse ModifyAfiliate(AfiliateDTO commerce)
        {
            var response = new ActionResponse();

            try
            {
       
                if(commerce.Telefonos.Count > 1)
                {
                    var addAfiliate = _context.Database.ExecuteSqlRaw("CALL UPDATE_AFILIADO({0},{1},{2},{3},{4},{5},{6},{7},{8},{9});",
                    commerce.CedulaJuridica,commerce.NombreComercio,commerce.SinpeMovil,commerce.Correo,
                    commerce.Provincia,commerce.Canton,commerce.Distrito,commerce.Tipo,commerce.Telefonos[0],commerce.Telefonos[1]);

                }
                else
                {
                    var addAfiliate = _context.Database.ExecuteSqlRaw("CALL UPDATE_AFILIADO({0},{1},{2},{3},{4},{5},{6},{7},{8});",
                    commerce.CedulaJuridica,commerce.NombreComercio,commerce.SinpeMovil,commerce.Correo,
                    commerce.Provincia,commerce.Canton,commerce.Distrito,
                    commerce.Tipo,commerce.Telefonos[0]);
                    response.actualizado = true;

                }

                response.actualizado = true;
                response.mensaje = "Afiliado actualizado exitosamente";

            }
            catch(Exception e)
            {
                response.actualizado = false;
                response.mensaje = "Error al actualizar afiliado";
                Console.WriteLine(e.Message);
            }
            
            return response;
        }

        public ActionResponse ModifyAfiAdmin(AdminAfiDTO newAdmin)
        {
            var response = new ActionResponse();

            try
            {
                if (newAdmin.Telefonos.Count > 1)
                {
                    var addAdmin = _context.Database.ExecuteSqlRaw("CALL UPDATE_AFI_ADMIN({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10});",
                    newAdmin.Nombre, newAdmin.PrimerApellido, newAdmin.SegundoApellido,
                    newAdmin.CorreoElectronico, newAdmin.UsuarioAdminAfi, newAdmin.PasswordAdminAfi, newAdmin.Provincia,
                    newAdmin.Canton, newAdmin.Distrito, newAdmin.Telefonos[0], newAdmin.Telefonos[1]);

                }
                else
                {
                    var addAdmin = _context.Database.ExecuteSqlRaw("CALL UPDATE_AFI_ADMIN({0},{1},{2},{3},{4},{5},{6},{7},{8},{9});",
                    newAdmin.Nombre, newAdmin.PrimerApellido, newAdmin.SegundoApellido,
                    newAdmin.CorreoElectronico, newAdmin.UsuarioAdminAfi, newAdmin.PasswordAdminAfi, newAdmin.Provincia,
                    newAdmin.Canton, newAdmin.Distrito, newAdmin.Telefonos[0]);
                }

                response.actualizado = true;
                response.mensaje = "Administrador de comercio afiliado actualizado exitosamente";
            }
            catch(Exception e)
            {
                response.actualizado = false;
                response.mensaje = "Error al actualizar administrador de comercio afiliado";
                Console.WriteLine(e.Message);
            }

            return response;
            
        }

        public ActionResponse ReplaceAfiAdmin(ReplaceAdminRequest newAdmin)
        {
            var response = new ActionResponse();

            try
            {
                if(newAdmin.Telefonos.Count > 1)
                {
                    var admin = _context.Database.ExecuteSqlRaw("CALL REPLACE_AFI_ADMIN({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13});",
                    newAdmin.CedulaJuridica,newAdmin.UsuarioAnterior,newAdmin.Nombre,newAdmin.PrimerApellido,newAdmin.SegundoApellido,
                    newAdmin.CorreoElectronico,newAdmin.UsuarioAdminAfi,newAdmin.PasswordAdminAfi,newAdmin.Provincia,
                    newAdmin.Canton,newAdmin.Distrito,newAdmin.Activo,newAdmin.Telefonos[0],newAdmin.Telefonos[1]);
                }
                else
                {
                    var admin = _context.Database.ExecuteSqlRaw("CALL REPLACE_AFI_ADMIN({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12});",
                    newAdmin.CedulaJuridica,newAdmin.UsuarioAnterior,newAdmin.Nombre,newAdmin.PrimerApellido,newAdmin.SegundoApellido,
                    newAdmin.CorreoElectronico,newAdmin.UsuarioAdminAfi,newAdmin.PasswordAdminAfi,newAdmin.Provincia,
                    newAdmin.Canton,newAdmin.Distrito,newAdmin.Activo,newAdmin.Telefonos[0]);
                }
                
                response.actualizado = true;
                response.mensaje = "Administrador del comercio afiliado remplazado exitosamente";
            }
            catch(Exception e)
            {
                response.actualizado = false;
                response.mensaje = "Error al cambiar administrador del comercio afiliado";
                Console.WriteLine(e.Message);
            }
            return response;
            
        }
    }

    
}