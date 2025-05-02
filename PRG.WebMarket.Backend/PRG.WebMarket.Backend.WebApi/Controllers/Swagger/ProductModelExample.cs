using System.Diagnostics.CodeAnalysis;
using PRG.WebMarket.Backend.Domain.Model;
using Swashbuckle.AspNetCore.Filters;

namespace PRG.WebMarket.Backend.WebApi.Controllers.Swagger
{
    // Marca que esta clase debe ignorarse cuando se calculan los porcentajes de cobertura de tests
    [ExcludeFromCodeCoverage]
    public class ProductModelExample : IExamplesProvider<ProductModel>
    {
        public ProductModel GetExamples()
        {
            return new ProductModel()
            {
                Name = "Play Station 5 pro 1tb",
                Description = "La consola de videojuegos más potente del mercado",
                Price = 499.99m,
                Stock = 100
            };
        }
    }
}
