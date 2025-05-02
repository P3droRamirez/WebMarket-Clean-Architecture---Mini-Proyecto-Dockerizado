
using MediatR;
using PRG.WebMarket.Backend.Domain.Model;

namespace PRG.WebMarket.Backend.Application.Features.Products.Commands
{

    public class CreateProductCommand : IRequest<OkResponseModel>
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Stock { get; set; }

        public CreateProductCommand(string name, string description, decimal price, int stock)
        {
            Name = name;
            Description = description;
            Price = price;
            this.Stock = stock;
        }
    }
}
