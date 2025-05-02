using MediatR;
using PRG.WebMarket.Backend.Application.Features.Orders.Commands;
using PRG.WebMarket.Backend.Application.Features.Orders.Queries;
using PRG.WebMarket.Backend.Domain.Contracts.Services;
using PRG.WebMarket.Backend.Domain.Model;

namespace PRG.WebMarket.Backend.Business.Services
{
    public class OrderService : IOrderService
    {
        private readonly IMediator _mediator;

        public OrderService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public Task<OkResponseModel> CreateOrderAsync(OrderModel model)
        {
            var orderCommand = new CreateOrderCommand(model);
            return _mediator.Send(orderCommand);
        }

        public Task<IEnumerable<OrderResponseModel>> GetAllOrdersAsync()
        {
            return _mediator.Send(new GetAllOrdersQuery());
        }

        public Task<OrderResponseModel> GetOrderByIdAsync(int id)
        {
            return _mediator.Send(new GetOrderByIdQuery(id));
        }
    }
}
