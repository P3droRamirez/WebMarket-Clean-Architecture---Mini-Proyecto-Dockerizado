using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRG.WebMarket.Backend.Domain.Model
{
    /// <summary>
    /// Esta clase se utiliza para devolver un  modelo de salida al cliente.
    /// </summary>
    public class ProductResponseModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Stock { get; set; }
    }
}
