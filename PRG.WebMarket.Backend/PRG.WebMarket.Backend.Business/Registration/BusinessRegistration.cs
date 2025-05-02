using Microsoft.Extensions.DependencyInjection;
using PRG.WebMarket.Backend.Business.Services;
using PRG.WebMarket.Backend.Domain.Contracts.Services;

namespace PRG.WebMarket.Backend.Business.Registration
{
    public static class BusinessRegistration
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            // Registramos ProductService como la implementación de IProductServices
            // Scoped significa: una instancia nueva por cada request HTTP
            services.AddScoped<IProductServices, ProductService>();

            // Registramos OrderService como la implementación de IOrderService
            // También una instancia nueva por request HTTP
            services.AddScoped<IOrderService, OrderService>();

            // Retornamos el contenedor de servicios actualizado
            return services;
        }
    }
}
