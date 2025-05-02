using System.Diagnostics.CodeAnalysis;
using PRG.WebMarket.Backend.Domain.Model;
using Swashbuckle.AspNetCore.Filters;

namespace PRG.WebMarket.Backend.WebApi.Controllers.Swagger
{
    [ExcludeFromCodeCoverage]
    public class OrderModelExample : IExamplesProvider<OrderModel>
    {
        public OrderModel GetExamples()
        {
            return new OrderModel
            {
                ProductIds = new List<int> { 1, 2, 3 } // IDs de productos seleccionados para la orden
            };
        }
    }
}
