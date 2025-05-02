

using PRG.WebMarket.Backend.Domain.Entities;

namespace PRG.WebMarket.Backend.Domain.Contracts.Repositories
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Task <Product> GetByNameAsync(string nameProduct);
    }
}
