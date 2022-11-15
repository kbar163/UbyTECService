using UbyTECService.Data.Context;
using UbyTECService.Data.Interfaces;
using UbyTECService.Models.Generated;
using UbyTECService.Models.ProductManagement;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace UbyTECService.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {

        private readonly ubytecdbContext _context;
        private readonly IMapper _mapper;

        public ProductRepository(ubytecdbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        //Proceso: Haciendo uso de EntityFramework.Core, obtiene todos los productos registrados en la base de datos.
        //Salida MultiProduct response; Contiene una propiedad booleana "exito" que indica si la operacion fue exitosa, y una propiedad lista
        //de Producto poblada con los objetos que representan los datos existentes en la base de datos.
        public MultiProduct GetAllProducts()
        {
            var response = new MultiProduct();
            try
            {
                var products = _context.Productos.ToList();
                var productsDTO = _mapper.Map<List<ProductDTO>>(products);

                

                if(products.Count != 0)
                {
                    foreach(ProductDTO element in productsDTO)
                    {
                        element.NombreCategoria = _context.Categoria.Find(element.IdCategoria).NombreCategoria;
                    }
                    response.exito = true;
                    response.productos = productsDTO;
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

        //Entrada: int id que representa el identificador de un producto
        //Proceso: Haciendo uso de EntityFramework.Core, obtiene un producto registrado en la base de datos basado en el id.
        //Salida: SingleProduct response; Contiene una propiedad booleana "exito" que indica si la operacion fue exitosa, y un
        //Producto que representa el dato del producto con el id que hace match con la entrada id.
        public SingleProduct GetProductById(int id)
        {
            var response = new SingleProduct();
            try
            {
                var product = _context.Productos
                .Where(p => p.IdProducto == id).FirstOrDefault<Producto>();
                var productDTO = _mapper.Map<ProductDTO>(product);

                if(product != null)
                {
                    productDTO.NombreCategoria = _context.Categoria.Find(productDTO.IdCategoria).NombreCategoria;
                    response.exito = true;
                    response.producto = productDTO;
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
    }
}