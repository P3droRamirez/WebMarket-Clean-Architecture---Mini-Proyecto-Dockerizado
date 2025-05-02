using MediatR;
using PRG.WebMarket.Backend.Domain.Model;

namespace PRG.WebMarket.Backend.Application.Features.Orders.Queries
{
    public class GetAllOrdersQuery : IRequest<IEnumerable<OrderResponseModel?>>
    {
    
    }
    
}
