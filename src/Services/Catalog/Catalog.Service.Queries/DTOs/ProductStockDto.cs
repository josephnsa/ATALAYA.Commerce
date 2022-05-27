using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Service.Queries.DTOs
{
    public class ProductStockDto
    {
        public int ProductStockId { get; set; }
        public int ProductId { get; set; }
        public int Stock { get; set; }
    }
}
