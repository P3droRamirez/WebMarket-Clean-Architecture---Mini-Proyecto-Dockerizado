using Microsoft.EntityFrameworkCore;
using PRG.WebMarket.Backend.Domain.Contracts.Repositories;
using PRG.WebMarket.Backend.Domain.Entities;
using PRG.WebMarket.Backend.Infrastructure.Context;

namespace PRG.WebMarket.Backend.Infrastructure.Repositories
{
    // Clase que implementa el contrato de acceso a datos (repositorio)
    public class ProductRepository : IProductRepository
    {

        private readonly AppDbContext _context;

        // Constructor que inyecta el contexto (DbContext) de EF Core
        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Product entity)
        {
            await _context.Products.AddAsync(entity); // Agrega el producto
            await _context.SaveChangesAsync();        // Guarda los cambios en la base de datos
        }

        public async Task DeleteAsync(Product entity)
        {
            _context.Products.Remove(entity);          // Marca el producto para eliminar
            await _context.SaveChangesAsync();         // Aplica los cambios en la BD
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Products.ToListAsync(); // Lista completa de productos
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id); // SELECT WHERE Id = id
        }

        public async Task<Product> GetByNameAsync(string nameProduct)
        {
            return await _context.Products.FirstOrDefaultAsync(p => p.Name == nameProduct);
        }

        public async Task UpdateAsync(Product entity, int id)
        {
            // Busca el producto existente por ID
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                throw new KeyNotFoundException($"El producto con el id {id} no existe");
            }

            // Actualiza los campos permitidos
            product.Name = entity.Name;
            product.Price = entity.Price;
            product.Description = entity.Description;
            product.Stock = entity.Stock;

            // Guarda los cambios en la base de datos
            await _context.SaveChangesAsync();
        }
    }
}
