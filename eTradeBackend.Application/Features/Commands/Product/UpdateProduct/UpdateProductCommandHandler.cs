using eTradeBackend.Application.Repositories.ProductRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTradeBackend.Application.Features.Commands.Product.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest, UpdateProductCommandResponse>
    {
        private readonly IProductWriteRepository _productWriteRepository;
        private readonly IProductReadRepository _productReadRepository;

        public UpdateProductCommandHandler(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
        }

        async Task<UpdateProductCommandResponse> IRequestHandler<UpdateProductCommandRequest, UpdateProductCommandResponse>.Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            var product=await _productReadRepository.GetByIdAsync(request.ProductId);
            if(product !=null)
            {
                product.Name = request.ProductName;
                product.Stock = request.Stock;
                product.Price = request.Price;
                await _productWriteRepository.SaveChange();

                return new();               
              
            }
            return new();
        }
    }
}
