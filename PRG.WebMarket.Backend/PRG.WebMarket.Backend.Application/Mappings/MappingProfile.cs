using AutoMapper;
using PRG.WebMarket.Backend.Application.Features.Products.Commands;
using PRG.WebMarket.Backend.Domain.Entities;
using PRG.WebMarket.Backend.Domain.Model;

namespace PRG.WebMarket.Backend.Application.Mappings
{
    /// <summary>
    /// Utilizamos esta clase para mapear entre Productos que se obtienen de la base de datos
    /// y de las diferentes clases commands en las que se altera la base de datos con los datos 
    /// introducidos por los clientes
    /// </summary>
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Mapea de Product (entidad de base de datos) a ProductResponseModel (modelo que se devuelve al cliente)
            // y viceversa (ReverseMap).
            CreateMap<Product, ProductResponseModel>().ReverseMap();

            // Mapea del comando de creación de productos a la entidad Product y viceversa.
            CreateMap<CreateProductCommand, Product>().ReverseMap();

            // Mapea del comando de actualización de productos a la entidad Product y viceversa.
            CreateMap<UpdateProductCommand, Product>().ReverseMap();

            // Mapea de la entidad Order al modelo de respuesta OrderResponseModel.
            // En particular, transforma la colección de OrderProduct a una lista con los nombres de productos.
            CreateMap<Order, OrderResponseModel>()
                .ForMember(dest => dest.Products, opt => opt.MapFrom(src =>
                    // src.Products es una lista de OrderProduct, accedemos a .Product y luego al .Name
                    src.Products.Select(op => op.Product)));

            // Mapea desde el modelo que se recibe en el POST (OrderModel) a la entidad Order.
            // Esto se usa para guardar una orden nueva a partir del input del cliente.
            CreateMap<OrderModel, Order>();

            // Mapea desde la entidad Product a un modelo de producto (ProductModel).
            CreateMap<Product, ProductModel>().ReverseMap();
        }
    }
}
