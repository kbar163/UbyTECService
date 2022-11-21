using UbyTECService.Data.Context;
using UbyTECService.Data.Interfaces;
using UbyTECService.Models.Generated;
using UbyTECService.Models.ProductManagement;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using UbyTECService.Models;

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

        //Entrada: ProductRequest newProduct; Continene los datos necesarios para crear un nuevo producto en la base de datos
        //Proceso: ejecuta el procedimiento almacenado correspondiente para crear un producto en la base de datos.
        public ActionResponse AddProduct(ProductRequest newProduct)
        {
            var response = new ActionResponse();

            try
            {
                var addProduct = _context.Database.ExecuteSqlRaw("CALL ADD_PRODUCT({0},{1},{2},{3},{4});",
                    newProduct.NombreProducto,newProduct.UrlFoto,newProduct.Precio,newProduct.CedulaJuridica,
                    newProduct.IdCategoria);
                    response.actualizado = true;
                    response.mensaje = "Producto creado exitosamente";

            }
            catch(Exception e)
            {
                response.actualizado = false;
                response.mensaje = "Error al crear producto";
            }

            return response;
        }

        //Entrada: IdRequest delAdmin; Continene el id de  un producto a eliminar en la base de datos
        //Proceso: Ejecuta el query de borrar haciendo uso del id.
        public ActionResponse DeleteProduct(NumIdRequest delProduct)
        {
            var response = new ActionResponse();
            try
            {
                var removeProduct = _context.Database.ExecuteSqlRaw("DELETE FROM PRODUCTO WHERE ID_PRODUCTO = {0};",delProduct.id);
                response.actualizado = true;
                response.mensaje = "Producto eliminado exitosamente";
            }
            catch(Exception e)
            {
                response.actualizado = false;
                response.mensaje = "Error al eleminar producto";
                Console.WriteLine(e.Message);
            }
            return response;
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

        public MultiProduct GetProductsByUser(string id)
        {
            var response = new MultiProduct();
            try
            {
                var afiliadoAdmin = _context.AfiliadoAdmins.Find(id);
                var products = _context.Productos.ToList().Where(p => p.CedulaJuridica == afiliadoAdmin.CedulaJuridica).ToList();
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

        //Entrada: ProductRequest newProduct; Continene los datos necesarios para modificar un producto en la base de datos
        //Proceso: ejecuta el procedimiento almacenado correspondiente para modificar un producto en la base de datos.
        public ActionResponse ModifyProduct(ProductRequest modProduct)
        {
            var response = new ActionResponse();

            try
            {
                var newProduct = _context.Database.ExecuteSqlRaw("CALL UPDATE_PRODUCT({0},{1},{2},{3});",
                    modProduct.IdProducto,modProduct.NombreProducto,modProduct.UrlFoto,modProduct.Precio);
                    response.actualizado = true;
                    response.mensaje = "Producto actualizado exitosamente";

            }
            catch(Exception e)
            {
                response.actualizado = false;
                response.mensaje = "Error al actualizar producto";
                Console.WriteLine(e.Message);
            }

            return response;
        }
    }
}