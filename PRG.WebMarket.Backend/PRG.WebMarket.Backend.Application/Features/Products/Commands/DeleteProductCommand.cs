
using MediatR;
using PRG.WebMarket.Backend.Domain.Model;

namespace PRG.WebMarket.Backend.Application.Features.Products.Commands
{
    public class DeleteProductCommand : IRequest<OkResponseModel>
    {
        public int Id { get; set; }

        public DeleteProductCommand(int id)
        {
            Id = id;
        }
    }
}
