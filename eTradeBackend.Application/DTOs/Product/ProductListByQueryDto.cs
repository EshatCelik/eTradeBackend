using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTradeBackend.Application.DTOs.Product
{
    public class ProductListByQueryDto:ProductListDto
    {
        public string? Query { get; set; }
    }
}
