using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using UbyTECService.Data.Interfaces;
using UbyTECService.Models;
using UbyTECService.Models.Generated;
using UbyTECService.Models.Login;
using UbyTECService.Models.UbyAdminManagement;

namespace UbyTECService.Controllers
{
    //UbyAdminController hereda la clase ControllerBase, utilizada para el manejo
    //del endpoints.
    //ApiController identifica a la clase como un controlador en el framework.
    //UbyAdminController se encarga de manejar los endpoints que permiten la gestion de administradores uby.
    //Route especifica la ruta para este controlador. En este caso local:
    //http://localhost:5068/api/UbyAdmin

    [Route("api/manage/UbyAdmin")]
    [ApiController]
    [EnableCors("Policy")]
    public class UbyAdminController : ControllerBase
    {
        private readonly IUbyAdminRepository _repository;

        public UbyAdminController(IUbyAdminRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public ActionResult<ActionResponse> AddUbyAdmin(UbyAdminRequest newAdmin )
        {
            var response = _repository.AddUbyAdmin(newAdmin);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public ActionResult<SingleUbyAdmin> GetUbyAdminById(string id)
        {
            var response = _repository.GetUbyAdminById(id);
            return Ok(response);
        }

        [HttpGet]
        public ActionResult<MultiUbyAdmin> GetAllUbyAdmin()
        {
            var response = _repository.GetAllUbyAdmin();
            return Ok(response);
        }

        [HttpPatch]
        public ActionResult<ActionResponse> ModifyUbyAdmin(UbyAdminRequest newAdmin )
        {
            var response = _repository.ModifyUbyAdmin(newAdmin);
            return Ok(response);
        }

        [HttpDelete]
        public ActionResult<ActionResponse> DeleteUbyAdmin(DeleteUbyAdminRequest delAdmin)
        {
            var response = _repository.DeleteUbyAdmin(delAdmin);
            return Ok(response);
        }
    }
}