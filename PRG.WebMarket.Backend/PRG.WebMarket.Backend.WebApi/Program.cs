
using FluentValidation.AspNetCore;
using MicroElements.Swashbuckle.FluentValidation.AspNetCore;
using PRG.WebMarket.Backend.Application.Features.Validators;
using PRG.WebMarket.Backend.Application.Mappings;
using PRG.WebMarket.Backend.Application.Registration;
using PRG.WebMarket.Backend.Business.Registration;
using PRG.WebMarket.Backend.Infrastructure.Registration;
using PRG.WebMarket.Backend.WebApi.Builders;
using PRG.WebMarket.Backend.WebApi.Registration;

namespace PRG.WebMarket.Backend.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            // Habilitar CORS para conectar con el Front.
            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.WithOrigins("http://localhost:4200") // URL del frontend (Angular)
                           .AllowAnyHeader()
                           .AllowAnyMethod();
                });
            });

            //Registrar Automapper
            builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

            // Registro de servicios (directorios 'Registration')
            builder.Services.AddApplicationServices(builder.Configuration);
            builder.Services.AddBusinessServices();
            builder.Services.AddInfrastructureServices(builder.Configuration);
            builder.Services.AddSwaggerServices();

            builder.Services.AddFluentValidation(conf =>
            conf.RegisterValidatorsFromAssemblyContaining<ProductModelValidator>());

            builder.Services.AddFluentValidationRulesToSwagger();

            builder.Services.AddControllers();

            var app = builder.Build();

            //Usar cors para conectar con Front.
            app.UseCors();

            app.AddSwaggerApp();

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
