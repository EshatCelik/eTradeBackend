using eTradeBackend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTradeBackend.Application.DTOs.Product
{
    public class ProductListDto
    {
        public ProductListDto()
        {
            Products = new List<ProductDto>(); 
        }
        public int TotalCount { get; set; }
        public List<ProductDto>? Products { get; set; }
    }
    public class ProductDto
    {
        public ProductDto()
        {
            ProductImageFiles = new List<ProductImageFile>();
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int  Stock { get; set; }
        public float Price { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public ICollection<ProductImageFile> ProductImageFiles { get; set; }
    }
}
