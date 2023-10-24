using eTradeBackend.Application.DTOs.Product;
using eTradeBackend.Application.Repositories.ProductRepository;
using eTradeBackend.Application.Services;
using eTradeBackend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace eTradeBackend.Persistance.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductReadRepository _productReadRepository;
        private readonly IQRCodeService _qrCodeService;

        public ProductService(IProductReadRepository productReadRepository, IQRCodeService qrCodeService)
        {
            _productReadRepository = productReadRepository;
            _qrCodeService = qrCodeService;
        }

        public  ProductListDto GetProductList(int page, int pageSize)
        {
            var total= _productReadRepository.GetAll(false).Count();
            var products= _productReadRepository.GetAll(false).Skip(page*pageSize).Take(pageSize)
                .Include(x=>x.ProductImageFiles)
                .Select(x=>new ProductDto()
                {
                    Id= x.Id,
                    Stock=x.Stock,
                    CreateDate=x.CreateDate,
                    Name=x.Name,
                    Price=x.Price,
                    ProductImageFiles=x.ProductImageFiles,
                    UpdateDate=x.UpdateDate
                }).ToList();

            return new() { Products = products,TotalCount=total};
        }

        public ProductListByQueryDto GetProductListByQuery(int page, int pageSize, string? query)
        {
            var queryable = _productReadRepository.GetAll(false).Where(x => x.Name.ToLower().Contains(query.ToLower()));

            var total=queryable.Count();

            var products = queryable.Skip(page * pageSize).Take(pageSize)
                .Include(x => x.ProductImageFiles)
                .Select(x => new ProductDto()
                {
                    Id = x.Id,
                    Stock = x.Stock,
                    CreateDate = x.CreateDate,
                    Name = x.Name,
                    Price = x.Price,
                    ProductImageFiles = x.ProductImageFiles,
                    UpdateDate = x.UpdateDate
                }).ToList();

            return new() { Products = products, TotalCount = total };
        }

        public async Task<byte[]> QRCodeToProductAsync(string productId)
        {
            Product product = await _productReadRepository.GetByIdAsync(productId);

            if (product == null) throw new Exception("Product Not Found!");

            var plainObject = new
            {
                product.Id,
                product.Name,
                product.Price,
                product.Stock,
                product.CreateDate
            };

            string plainText = JsonSerializer.Serialize(plainObject);

            return _qrCodeService.GenerateQRCodeAsync(plainText);
        }
    }
}
