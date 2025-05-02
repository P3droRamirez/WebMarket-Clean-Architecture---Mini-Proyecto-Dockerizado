using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRG.WebMarket.Backend.Domain.Model
{
    public class OrderResponseModel
    {
        public int Id { get; set; }
        public DateOnly Date { get; set; }
        public decimal Total { get; set; }
        public List<ProductModel> Products { get; set; } = new List<ProductModel>();
    }
}
