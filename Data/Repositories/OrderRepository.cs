using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UbyTECService.Data.Context;
using UbyTECService.Data.Interfaces;
using UbyTECService.Models;
using UbyTECService.Models.Generated;
using UbyTECService.Models.OrderManagement;

namespace UbyTECService.Data.Repositories
{
    //Implementacion de la logica para cada una de los endpoints expuesos en OrderController,
    //esta clase extiende la interfaz IOrderRepository, e implementa los metodos relacionados
    //a la manipulacion de datos necesaria para cumplir con los requerimientos funcionales
    //de la aplicacion.
    public class OrderRepository : IOrderRepository
    {
        private readonly ubytecdbContext _context;
        private readonly IMapper _mapper;

        public OrderRepository(ubytecdbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //Entrada: OrderRequest newOrder; Continene los datos necesarios para crear un nuevo pedido en la base de datos
        //Proceso: Revisa la cantidad y precio de productos que el usuario quiere ordenar en us pedido y acorde a esto calcula el valor del monto con 5% de
        //impuesto de servicio, agrega una nueva orden a la base de datos y agrega los productos a la tabla intermedia que relaciona las ordenes con los
        //productos.
        //Salida: ActionResponse response; Contiene un booleano que representa si la accion fue exitosa o fallida y un string mensaje.
        public ActionResponse AddOrder(OrderRequest newOrder)
        {
            var response = new ActionResponse();
            double totalPreTax = 0;

            try
            {
                foreach(OrderRequestProduct element in newOrder.Productos)
                {
                    totalPreTax += element.PrecioProducto*element.Cantidad;
                }

                double tax = totalPreTax * 0.05;
                double totalPostTax = totalPreTax + tax;

                var idPedido = _context.PostInsertID.FromSqlRaw("INSERT INTO PEDIDO VALUES (DEFAULT,{0},1,{1},{2},{3},{4},{5},{6}) RETURNING ID_PEDIDO;",
                totalPostTax,newOrder.CedulaCliente,newOrder.Provincia,newOrder.Canton,newOrder.Distrito,
                newOrder.CedulaJuridica,newOrder.Fecha).ToList();
                
                foreach(OrderRequestProduct element in newOrder.Productos)
                {
                    for(int quantity = 0; quantity < element.Cantidad; quantity++)
                    {
                        _context.Database.ExecuteSqlRaw("INSERT INTO PEDIDO_PRODUCTO VALUES(DEFAULT,{0},{1});",idPedido[0].IdPedido,element.IdProducto);
                    }
                    
                }
                response.actualizado = true;
                response.mensaje = "Pedido creado exitosamente";
            }
            catch(Exception e)
            {
                response.mensaje = "Error al crear pedido";
                Console.WriteLine(e.Message);
            }
            return response;
        }

        //Entrada: AssignOrder order; Continene los datos necesarios para asignar un repartidor a un pedido en la base de datos
        //Proceso: Llama al procedimiento almacenado que asigna repartidores a pedidos y modifica el objeto de respuesta de acuerdo al resultado del procedimiento.
        //Salida: ActionResponse response; Contiene un booleano que representa si la accion fue exitosa o fallida y un string mensaje.
        public ActionResponse AssignOrder(AssignOrder order)
        {
            var response = new ActionResponse();

            try
            {
                _context.Database.ExecuteSqlRaw("CALL ASSIGN_DELIVERY({0},{1},{2},{3});",order.Id,order.Provincia,order.Canton,order.Distrito);
                response.actualizado = true;
                response.mensaje = "Orden asignada exitosamente";
            }
            catch
            {
                response.mensaje = "Error al asignar orden";
            }

            return response;
        }

        //Proceso: Haciendo uso de EntityFramework.Core, obtiene todos los pedidos registrados en la base de datos.
        //Salida MultiOrder response; Contiene una propiedad booleana "exito" que indica si la operacion fue exitosa, y una propiedad lista
        //de OrderDTO poblada con los objetos que representan los datos existentes en la base de datos.
        public MultiOrder GetAllOrders()
        {
            var response = new MultiOrder();
            try
            {
                var pedidos = _context.Pedidos
                .Include(p => p.PedidoProductos).ToList();
                 
                if(pedidos.Count != 0)
                {
                    var ordersDTO = _mapper.Map<List<OrderDTO>>(pedidos);

                    for(int i = 0; i < ordersDTO.Count; i++)
                    {
                        ordersDTO[i].ProductosPedido = new List<OrderProduct>();
                        for(int j = 0; j < pedidos[i].PedidoProductos.Count; j++)
                        {
                            var orderProduct = new OrderProduct();
                            var product = _context.Productos.Find(pedidos[i].PedidoProductos.ElementAt(j).IdProducto);
                            orderProduct.PrecioProducto = product.Precio;
                            orderProduct.NombreProducto = product.NombreProducto;
                            ordersDTO[i].ProductosPedido.Add(orderProduct);
                        }
                    }
                    response.exito = true;
                    response.pedidos = ordersDTO;
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

        //Entrada: string id que representa el id de un pedido
        //Proceso: Haciendo uso de EntityFramework.Core, obtiene un pedido registrado en la base de datos basado en el id.
        //Salida: SingleOrder response; Contiene una propiedad booleana "exito" que indica si la operacion fue exitosa, y un
        //OrderDTO que representa el dato del repartidor con el usuario que hace match con la entrada id.
        public SingleOrder GetOrderById(int id)
        {
            var response = new SingleOrder();
            try
            {
                var pedido = _context.Pedidos
                .Include(p => p.PedidoProductos)
                .Where(p => p.IdPedido == id)
                .FirstOrDefault<Pedido>();

                if(pedido != null)
                {
                    var pedidoDTO = _mapper.Map<OrderDTO>(pedido);
                    pedidoDTO.ProductosPedido = new List<OrderProduct>();
                    foreach(PedidoProducto element in pedido.PedidoProductos.ToList())
                    {
                        var orderProduct = new OrderProduct();
                        var product = _context.Productos.Find(element.IdProducto);
                        orderProduct.PrecioProducto = product.Precio;
                        orderProduct.NombreProducto = product.NombreProducto;
                        pedidoDTO.ProductosPedido.Add(orderProduct);
                    }
                    response.exito = true;
                    response.pedido = pedidoDTO;
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

        //Entrada: OrderReceived received; Continene los datos necesarios para terminar el ciclo de un pedido en la base de datos
        //Proceso: Llama al procedimiento almacenado que finaliza el ciclo del pedido y modifica el objeto de respuesta de acuerdo al resultado del procedimiento.
        //Salida: ActionResponse response; Contiene un booleano que representa si la accion fue exitosa o fallida y un string mensaje.
        public ActionResponse OrderReceived(NumIdRequest received)
        {
            var response = new ActionResponse();

            try
            {
                _context.Database.ExecuteSqlRaw("CALL CONFIRM_ORDER({0});",received.id);
                response.actualizado = true;
                response.mensaje = "Orden terminada exitosamente";
            }
            catch
            {
                response.mensaje = "Error al terminar orden";
            }

            return response;
        }
    }
}