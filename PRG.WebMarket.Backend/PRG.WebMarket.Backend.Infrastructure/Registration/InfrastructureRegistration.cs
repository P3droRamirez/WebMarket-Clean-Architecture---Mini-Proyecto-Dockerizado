using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PRG.WebMarket.Backend.Domain.Contracts.Repositories;
using PRG.WebMarket.Backend.Infrastructure.Context;
using PRG.WebMarket.Backend.Infrastructure.Repositories;


namespace PRG.WebMarket.Backend.Infrastructure.Registration
{
    // Clase estática para registrar servicios de la capa de infraestructura
    public static class InfrastructureRegistration
    {
        // Método de extensión que registra los servicios en el contenedor de dependencias
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Registro del DbContext de Entity Framework
            // Esto configura EF Core para que use SQL Server como proveedor
            // y obtenga la cadena de conexión desde ConfigurationManager.LocalDB
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Application.Registration.ConfigurationManager.LocalDB));
            // Registro del repositorio de productos
            // Se registra la implementación concreta de IProductRepository
            // como un servicio Scoped (una instancia por request HTTP)
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();

            return services;
        }
    }
}
