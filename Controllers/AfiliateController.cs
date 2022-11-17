using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using UbyTECService.Data.Interfaces;
using UbyTECService.Models;
using UbyTECService.Models.AfiliateManagement;


namespace UbyTECService.Controllers
{
    //AfiliateController hereda la clase ControllerBase, utilizada para el manejo
    //del endpoints.
    //ApiController identifica a la clase como un controlador en el framework.
    //AfiliateController se encarga de manejar los endpoints que permiten la gestion de afiliados.
    //Route especifica la ruta para este controlador. En este caso local:
    //http://localhost:5068/api/manage/afiliado

    [Route("api/manage/afiliado")]
    [ApiController]
    [EnableCors("Policy")]
    public class AfiliateController : ControllerBase
    {
        private readonly IAfiliateRepository _repository;

        public AfiliateController(IAfiliateRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public ActionResult<ActionResponse> AddAfiliate(AfiliateData newAfiliate )
        {
            var response = _repository.AddAfiliate(newAfiliate);
            return Ok(response);
        }

        [HttpPost("afiadmin/replace")]
        public ActionResult<ActionResponse> ReplaceAfiAdmin(ReplaceAdminRequest newAfiAdmin )
        {
            var response = _repository.ReplaceAfiAdmin(newAfiAdmin);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public ActionResult<SingleAfiliate> GetAfiliateById(string id)
        {
            var response = _repository.GetAfiliateById(id);
            return Ok(response);
        }

        [HttpGet]
        public ActionResult<MultiAfiliate> GetAllAfiliates()
        {
            var response = _repository.GetAllAfiliates();
            return Ok(response);
        }

        [HttpPatch]
        public ActionResult<ActionResponse> ModifyAfiliate(AfiliateDTO modAfiliate )
        {
            var response = _repository.ModifyAfiliate(modAfiliate);
            return Ok(response);
        }

        [HttpPatch("afiadmin")]
        public ActionResult<ActionResponse> ModifyAfiAdmin(AdminAfiDTO modAdmin )
        {
            var response = _repository.ModifyAfiAdmin(modAdmin);
            return Ok(response);
        }

    }
}