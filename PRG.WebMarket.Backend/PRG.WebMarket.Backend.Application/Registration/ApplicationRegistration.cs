using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace PRG.WebMarket.Backend.Application.Registration
{
    // Esta clase estática extiende IServiceCollection y se encarga de registrar
    // todos los servicios de la capa Application (como AutoMapper, MediatR, etc.)
    public static class ApplicationRegistration
    {
        // Método de extensión que se llama desde Program.cs
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Se guarda la configuración global (appsettings.json, variables de entorno, etc.)
            // en una clase ConfigurationManager personalizada, para usarla en toda la app.
            ConfigurationManager.Configuration = configuration;

            // Registra todos los perfiles de AutoMapper (Profile) que existan en esta capa (Application).
            // Esto permite convertir entidades a modelos de respuesta y viceversa.
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            // Registra todos los handlers de MediatR (comandos, queries) que se encuentren en esta capa.
            // Esto permite que se resuelvan automáticamente al hacer mediator.Send(...)
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            // Devuelve el contenedor de servicios actualizado para que se puedan encadenar otros registros.
            return services;
        }
    }
}
