using PRG.WebMarket.Backend.Domain.Model;

namespace PRG.WebMarket.Backend.Domain.Contracts.Services
{
    public interface IProductServices
    {
        Task<IEnumerable<ProductResponseModel>> GetAllAsync();
        Task<ProductResponseModel> GetByIdAsync(int id);
        Task<ProductResponseModel> GetByNameAsync(string nameProduct);
        Task<OkResponseModel> AddAsync(ProductModel product);
        Task<OkResponseModel> UpdateAsync(ProductModel product, int id);
        Task<OkResponseModel> DeleteAsync(int id);
    }
}
