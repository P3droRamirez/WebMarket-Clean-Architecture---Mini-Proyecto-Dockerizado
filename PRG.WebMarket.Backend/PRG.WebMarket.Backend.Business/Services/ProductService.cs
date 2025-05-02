
using System.Reflection;
using MediatR;
using PRG.WebMarket.Backend.Application.Features.Products.Commands;
using PRG.WebMarket.Backend.Application.Features.Products.Queries;
using PRG.WebMarket.Backend.Domain.Contracts.Services;
using PRG.WebMarket.Backend.Domain.Model;

namespace PRG.WebMarket.Backend.Business.Services
{
    public class ProductService : IProductServices
    {
        private readonly IMediator _mediator;

        public ProductService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<OkResponseModel> AddAsync(ProductModel product)
        {
            var productCommand = new CreateProductCommand(product.Name, product.Description, product.Price, product.Stock);
            return await _mediator.Send(productCommand);
        }

        public Task<OkResponseModel> DeleteAsync(int id)
        {
            var productCommand = new DeleteProductCommand(id);
            return _mediator.Send(productCommand);
        }

        public async Task<IEnumerable<ProductResponseModel>> GetAllAsync()
        {
            return await _mediator.Send(new GetAllProductsQuery()); 
        }

        public async Task<ProductResponseModel> GetByIdAsync(int id)
        {
            return await _mediator.Send(new GetProductByIdQuery(id));
        }

        public Task<ProductResponseModel> GetByNameAsync(string nameProduct)
        {
            throw new NotImplementedException();
        }

        public async Task<OkResponseModel> UpdateAsync(ProductModel product, int id)
        {
            var productCommand = new UpdateProductCommand(id, product.Name,product.Description, product.Price, product.Stock);
            return await _mediator.Send(productCommand);
        }
    }
}
