using MediatR;
using PRG.WebMarket.Backend.Domain.Model;

namespace PRG.WebMarket.Backend.Application.Features.Orders.Commands
{
    public class CreateOrderCommand : IRequest<OkResponseModel>
    {
        public CreateOrderCommand(OrderModel model)
        {
            Model = model;
        }
        public OrderModel Model { get; set; }
    }
}
