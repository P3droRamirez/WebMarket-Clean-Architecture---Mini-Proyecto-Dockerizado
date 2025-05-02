using AutoMapper;
using MediatR;
using PRG.WebMarket.Backend.Application.Features.Orders.Commands;
using PRG.WebMarket.Backend.Application.Features.Orders.Queries;
using PRG.WebMarket.Backend.Domain.Contracts.Repositories;
using PRG.WebMarket.Backend.Domain.Entities;
using PRG.WebMarket.Backend.Domain.Model;

namespace PRG.WebMarket.Backend.Application.Features
{
    public class OrderHandler :
        IRequestHandler<CreateOrderCommand, OkResponseModel>,
        IRequestHandler<GetAllOrdersQuery, IEnumerable<OrderResponseModel>>,
        IRequestHandler<GetOrderByIdQuery, OrderResponseModel>

    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public OrderHandler(IOrderRepository orderRepository, IProductRepository productRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _mapper = mapper;
        }
        //Metodo para crear una orden de compra de productos
        public async Task<OkResponseModel> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = new Order
            {
                Date = DateOnly.FromDateTime(DateTime.Now),
                Products = new List<OrderProduct>()
            };

            decimal total = 0;

            foreach (var productId in request.Model.ProductIds)
            {
                var product = await _productRepository.GetByIdAsync(productId);
                if (product != null)
                {
                    order.Products.Add(new OrderProduct
                    {
                        Product = product,
                        ProductId = product.Id
                    });
                    total += product.Price;
                }
            }
            order.Total = total;

            await _orderRepository.AddAsync(order);
            return new OkResponseModel
            {
                Id = order.Id,
                Message = "Orden creada con éxito"
            };
        }

        public async Task<IEnumerable<OrderResponseModel>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            var orders = await _orderRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<OrderResponseModel>>(orders);
        }

        public async Task<OrderResponseModel?> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetByIdAsync(request.Id);
            return order != null ? _mapper.Map<OrderResponseModel>(order) : null;
        }
    }
}
