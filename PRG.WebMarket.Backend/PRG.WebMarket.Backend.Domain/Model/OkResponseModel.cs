using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRG.WebMarket.Backend.Domain.Model
{
    /// <summary>
    /// Esta clase se utiliza para devolver una respuesta de éxito al cliente.
    /// </summary>
    public class  OkResponseModel
    {
        public int Id { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}
