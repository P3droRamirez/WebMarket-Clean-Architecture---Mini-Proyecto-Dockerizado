
using AutoMapper;
using MediatR;
using PRG.WebMarket.Backend.Application.Features.Products.Commands;
using PRG.WebMarket.Backend.Application.Features.Products.Queries;
using PRG.WebMarket.Backend.Domain.Contracts.Repositories;
using PRG.WebMarket.Backend.Domain.Entities;
using PRG.WebMarket.Backend.Domain.Model;

namespace PRG.WebMarket.Backend.Application.Features
{
    public class ProductHandler :
        IRequestHandler<GetAllProductsQuery, IEnumerable<ProductResponseModel>>,
        IRequestHandler<CreateProductCommand, OkResponseModel>,
        IRequestHandler<DeleteProductCommand, OkResponseModel>,
        IRequestHandler<GetProductByIdQuery, ProductResponseModel?>,
        IRequestHandler<UpdateProductCommand, OkResponseModel?>

    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ProductResponseModel>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ProductResponseModel>>(products);
        }

        public async Task<OkResponseModel> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(request);
            await _productRepository.AddAsync(product);
            return new OkResponseModel
            {
                Id = product.Id,
                Message = "El producto ha sido creado con éxito"
            };
        }

        public async Task<OkResponseModel?> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.Id);
            await _productRepository.DeleteAsync(product);

            return new OkResponseModel
            {
                Id = product.Id,
                Message = "El producto ha sido borrado con éxito"
            };
        }

        public async Task<ProductResponseModel?> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.Id);
            return _mapper.Map<ProductResponseModel>(product);
        }

        public async Task<OkResponseModel?> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(request);
            await _productRepository.UpdateAsync(product, request.Id);

            return new OkResponseModel
            {
                Id = request.Id,
                Message = "Producto actualizado correctamente"
            };
        }
    }
}
