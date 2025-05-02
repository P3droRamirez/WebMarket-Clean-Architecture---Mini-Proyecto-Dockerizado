using Microsoft.Extensions.Configuration;

namespace PRG.WebMarket.Backend.Application.Registration
{
    // Esta clase actúa como un "acceso global" a valores de configuración (appsettings.json)
    // desde cualquier parte de la aplicación sin tener que inyectar IConfiguration en todas las clases.
    public class ConfigurationManager
    {
        // Aquí se guarda la instancia de IConfiguration cuando se inicia la aplicación.
        // Se establece desde ApplicationRegistration.cs, en el método AddApplicationServices.
        public static IConfiguration? Configuration { get; set; }

        // ------------------------------------
        //            SWAGGER
        // ------------------------------------

        // Devuelve true o false dependiendo de si Swagger está habilitado
        // en el archivo de configuración (appsettings.json → "Swagger:Enabled")
        #region Swagger
        public static bool SwaggerEnabled
        {
            get
            {
                if (Configuration != null && bool.TryParse(Configuration["Swagger:Enabled"], out bool enabled))
                {
                    return enabled;
                }
                return false; // Si no se encuentra el valor, Swagger se desactiva por defecto
            }
        }

        // ------------------------------------
        //         CONNECTION STRINGS
        // ------------------------------------

        // Devuelve la cadena de conexión configurada en appsettings.json bajo "ConnectionStrings:Connection"
        #endregion Swagger

        #region ConnectionStrings
        public static string? LocalDB
        {
            get
            {
                return Configuration != null ? Configuration["ConnectionStrings:Connection"] : string.Empty;
            }
        }
    }
#endregion ConnectionStrings
}
