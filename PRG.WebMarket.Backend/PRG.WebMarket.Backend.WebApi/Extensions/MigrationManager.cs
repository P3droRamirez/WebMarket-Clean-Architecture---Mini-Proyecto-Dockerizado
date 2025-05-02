using Microsoft.EntityFrameworkCore;
using PRG.WebMarket.Backend.Infrastructure.Context;

namespace PRG.WebMarket.Backend.WebApi.Extensions
{
    public static class MigrationManager
    {
        public static void ApplyMigrations(this IApplicationBuilder app)
        {
            using IServiceScope scope = app.ApplicationServices.CreateScope();

            using AppDbContext dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            dbContext.Database.Migrate();
        }
    }
}
