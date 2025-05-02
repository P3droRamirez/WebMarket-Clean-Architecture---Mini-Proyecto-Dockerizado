using MediatR;
using PRG.WebMarket.Backend.Domain.Model;

namespace PRG.WebMarket.Backend.Application.Features.Orders.Queries
{
    public class GetOrderByIdQuery : IRequest<OrderResponseModel?>
    {
        public int Id { get; set; }
        public GetOrderByIdQuery(int id)
        {
            Id = id;
        }
    }
}
