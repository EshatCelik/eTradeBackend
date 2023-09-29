using eTradeBackend.Application.Repositories.ProductRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTradeBackend.Application.Features.Commands.ProductImageFile.RemoveProductImage
{
    public class RemoveProductImageCommandHandler : IRequestHandler<RemoveProductImageCommandRequest, RemoveProductImageCommandResponse>
    {
        private readonly IProductReadRepository _productReadRepository;
        private readonly IProductWriteRepository _productWriteRepository;

        public RemoveProductImageCommandHandler(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
        }


        public async Task<RemoveProductImageCommandResponse> Handle(RemoveProductImageCommandRequest request, CancellationToken cancellationToken)
        {
            var product = await _productReadRepository.Table.Include(x => x.ProductImageFiles).FirstOrDefaultAsync(x => x.Id == Guid.Parse(request.Id));

            var productImage = product.ProductImageFiles.FirstOrDefault(x => x.Id == Guid.Parse(request.ImageId));

            if (productImage != null)
                product.ProductImageFiles.Remove(productImage);

            await _productWriteRepository.SaveChange();
            return new();
        }
    }
}
