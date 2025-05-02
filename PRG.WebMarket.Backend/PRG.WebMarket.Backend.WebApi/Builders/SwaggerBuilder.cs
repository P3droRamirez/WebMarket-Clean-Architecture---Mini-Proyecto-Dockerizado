using PRG.WebMarket.Backend.WebApi.Extensions;

namespace PRG.WebMarket.Backend.WebApi.Builders
{
    // Clase estática que actúa como extensión para configurar Swagger en tiempo de ejecución
    public static class SwaggerBuilder
    {
        // Método de extensión para IApplicationBuilder (se llama desde Program.cs)
        public static IApplicationBuilder AddSwaggerApp(this IApplicationBuilder app)
        {
            // Obtiene desde el archivo de configuración si Swagger está habilitado
            var enabled = Application.Registration.ConfigurationManager.SwaggerEnabled;

            // Verifica dos cosas antes de activar Swagger:
            // 1. Que el entorno sea "Development"
            // 2. Que la opción Swagger:Enabled sea true en appsettings.json
            if (((WebApplication)app).Environment.IsDevelopment() && enabled)
            {
                app.UseSwagger();// Activa el middleware que expone el JSON de Swagger
                app.UseSwaggerUI();// Activa la interfaz visual interactiva de Swagger (Swagger UI)
                app.ApplyMigrations();// Aplica las migraciones pendientes a la base de datos
            }

            // Devuelve el objeto app para encadenar llamadas (fluidez en Program.cs)
            return app;
        }
    }
}
