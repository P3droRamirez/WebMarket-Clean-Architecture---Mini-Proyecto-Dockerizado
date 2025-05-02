using Microsoft.EntityFrameworkCore;
using PRG.WebMarket.Backend.Domain.Contracts.Repositories;
using PRG.WebMarket.Backend.Domain.Entities;
using PRG.WebMarket.Backend.Infrastructure.Context;

namespace PRG.WebMarket.Backend.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {

        private readonly AppDbContext _context;

        public OrderRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Order order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Order entity)
        {
            _context.Orders.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await _context.Orders
                .Include(o => o.Products)
                .ThenInclude(op => op.Product)
                .ToListAsync();
        }

        public async Task<Order> GetByIdAsync(int id)
        {
            return await _context.Orders
                .Include(o => o.Products)
                .ThenInclude(op => op.Product)
                .FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task UpdateAsync(Order entity, int id)
        {
            var existing = await _context.Orders.FindAsync(id);
            if (existing is null)
                throw new KeyNotFoundException($"No se encontró la orden con ID {id}");

            existing.Total = entity.Total;
            existing.Date = entity.Date;
            existing.Products = entity.Products;

            await _context.SaveChangesAsync();
        }
    }
}
