using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using UbyTECService.Data.Interfaces;
using UbyTECService.Models;
using UbyTECService.Models.ProductManagement;

namespace UbyTECService.Controllers
{
    //ProductController hereda la clase ControllerBase, utilizada para el manejo
    //de endpoints.
    //ApiController identifica a la clase como un controlador en el framework.
    //ProductController se encarga de manejar los endpoints que permiten la gestion de productos.
    //Route especifica la ruta para este controlador. En este caso local:
    //http://localhost:5068/api/repartidor

    [Route("api/manage/producto")]
    [ApiController]
    [EnableCors("Policy")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _repository;

        public ProductController(IProductRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public ActionResult<ActionResponse> AddProduct(ProductRequest newProduct )
        {
            var response = _repository.AddProduct(newProduct);
            return Ok(response);
        }

        [HttpGet("id/{id}")]
        public ActionResult<SingleProduct> GetProductById(int id)
        {
            var response = _repository.GetProductById(id);
            return Ok(response);
        }

        [HttpGet]
        public ActionResult<MultiProduct> GetAllProducts()
        {
            var response = _repository.GetAllProducts();
            return Ok(response);
        }

        [HttpGet ("usr/{usr}")]
        public ActionResult<MultiProduct> GetProductsByUser(string usr)
        {
            var response = _repository.GetProductsByUser(usr);
            return Ok(response);
        }

        [HttpPatch]
        public ActionResult<ActionResponse> ModifyProduct(ProductRequest modProduct )
        {
            var response = _repository.ModifyProduct(modProduct);
            return Ok(response);
        }

        [HttpDelete]
        public ActionResult<ActionResponse> DeleteProduct(NumIdRequest delProduct)
        {
            var response = _repository.DeleteProduct(delProduct);
            return Ok(response);
        }
    }
}