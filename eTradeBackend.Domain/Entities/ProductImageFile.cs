using eTradeBackend.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTradeBackend.Domain.Entities
{
    public class ProductImageFile:BaseEntity
    {
        public bool ShowCase { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
