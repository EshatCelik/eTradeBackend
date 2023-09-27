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
        ProductListDto GetProductList(int page, int pageSize);
        ProductListByQueryDto GetProductListByQuery(int page, int pageSize, string? query);
        Task<byte[]> QRCodeToProductAsync(string productId);
    }
}
