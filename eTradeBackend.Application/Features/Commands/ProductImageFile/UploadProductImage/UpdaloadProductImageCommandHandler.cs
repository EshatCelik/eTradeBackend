using eTradeBackend.Application.Abstract.Storage;
using eTradeBackend.Application.Repositories.ProductImageFileRepository;
using eTradeBackend.Application.Repositories.ProductRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTradeBackend.Application.Features.Commands.ProductImageFile.UploadProductImage
{
    public class UpdaloadProductImageCommandHandler : IRequestHandler<UpdaloadProductImageCommandRequest, UpdaloadProductImageCommandResponse>
    {
        private readonly IStorageService _storageService;
        private readonly IProductReadRepository productReadRepository;
        private readonly IProductImageFileWriteRepository productImageFileWriteRepository;

        public UpdaloadProductImageCommandHandler(IStorageService storageService, IProductReadRepository productReadRepository, 
            IProductImageFileWriteRepository productImageFileWriteRepository)
        {
            _storageService = storageService;
            this.productReadRepository = productReadRepository;
            this.productImageFileWriteRepository = productImageFileWriteRepository;
        }

        public async Task<UpdaloadProductImageCommandResponse> Handle(UpdaloadProductImageCommandRequest request, CancellationToken cancellationToken)
        {
            var result = await _storageService.UploadAsync("product-images", request.FormFiles);
            var product = await productReadRepository.GetByIdAsync(request.Id);

            await productImageFileWriteRepository.AddRangeAsync(result.Select(x => new Domain.Entities.ProductImageFile()
            {
                FileName = x.fileName,
                Path = x.pathOrContainerNane,
                StorageType = _storageService.StorageName,
                Products = new List<Domain.Entities.Product>() { product }
            }).ToList());

            await productImageFileWriteRepository.SaveChange();
            return new();
        }
    }
}
