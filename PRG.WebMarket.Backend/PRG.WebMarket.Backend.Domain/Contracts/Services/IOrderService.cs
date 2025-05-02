using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PRG.WebMarket.Backend.Domain.Model;

namespace PRG.WebMarket.Backend.Domain.Contracts.Services
{
    public interface IOrderService 
    {
        Task<OkResponseModel> CreateOrderAsync(OrderModel model);
        Task<IEnumerable<OrderResponseModel>> GetAllOrdersAsync();
        Task<OrderResponseModel> GetOrderByIdAsync(int id);

       
    }
}
