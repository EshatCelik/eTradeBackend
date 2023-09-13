using eTradeBackend.Application.DTOs.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTradeBackend.Application.Services
{
    public interface IProductService
    {
        Task<ProductListDto> GetProductList(int page, int pageSize);
        Task<ProductListByQueryDto> GetProductListByQuery(int page, int pageSize, string? query);
        Task<byte[]> QRCodeToProductAsync(string productId);
    }
}
