
using Microsoft.OpenApi.Models;
using System.Reflection;
using Swashbuckle.AspNetCore.Filters;


namespace PRG.WebMarket.Backend.WebApi.Registration
{
    // Clase estática que extiende IServiceCollection para registrar Swagger en tiempo de compilación
    public static class SwaggerRegistration
    {
        public static IServiceCollection AddSwaggerServices(this IServiceCollection services)
        {
            // Obtiene la configuración para saber si Swagger está habilitado
            var enabled = Application.Registration.ConfigurationManager.SwaggerEnabled;

            // Solo registra Swagger si está habilitado en appsettings.json
            if (enabled)
            {
                //Necesario para que Swagger explore los endpoints anotados con [HttpX]
                services.AddEndpointsApiExplorer();

                //Agrega ejemplos desde ensamblados (como ProductModelExample)
                services.AddSwaggerExamplesFromAssemblies(Assembly.GetEntryAssembly());

                // Configura Swagger (documentación, título, descripción, etc.)
                services.AddSwaggerGen(c =>
                {
                    // Activa los filtros de ejemplos (como [SwaggerResponseExample])
                    c.ExampleFilters();

                    // Define la información principal del SwaggerDoc
                    c.SwaggerDoc("v1", new OpenApiInfo
                    {
                        Version = "v1",
                        Title = "Products API",
                        Description = "Simple ASP.NET Core Web Api para Crud de productos",
                        Contact = new OpenApiContact
                        {
                            Name = "Pedro Ramirez Gonzalez",
                            Email = "pedroramirez_1991@hotmail.com",
                            Url = new Uri("https://github.com/P3droRamirez_"),
                        },
                        License = new OpenApiLicense
                        {
                            Name = "MIT License",
                            Url = new Uri("https://opensource.org/licenses/MIT")
                        },
                    });

                    //Agrega la documentación XML generada por los comentarios de tus métodos (///)
                    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFilename);

                    //Si existe el archivo XML, lo incluye en Swagger
                    if (File.Exists(xmlPath))
                    {
                        c.IncludeXmlComments(xmlPath);
                    }
                    else
                    {
                        //Muestra un aviso si no encuentra el XML (no obligatorio, solo informativo)
                        Console.WriteLine($"XML documentation file not found: {xmlPath}");
                    }
                });
            }

            // Devuelve el contenedor con los servicios registrados
            return services;
        }
    }

}
