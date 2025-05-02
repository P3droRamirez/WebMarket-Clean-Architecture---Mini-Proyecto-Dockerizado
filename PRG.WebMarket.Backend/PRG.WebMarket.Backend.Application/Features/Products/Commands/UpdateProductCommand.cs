using MediatR;
using PRG.WebMarket.Backend.Domain.Model;

namespace PRG.WebMarket.Backend.Application.Features.Products.Commands
{
    public class UpdateProductCommand : IRequest<OkResponseModel>
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Stock { get; set; }

        public UpdateProductCommand(int id, string name, string description, decimal price, int stock)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
        }
    }
}
