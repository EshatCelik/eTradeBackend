using eTradeBackend.Application.Repositories.ProductImageFileRepository;
using eTradeBackend.Application.Repositories.ProductRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTradeBackend.Application.Features.Commands.ProductImageFile.ChangeShowCaseImage
{
    public class ChangeShowCaseImageCommandHandler : IRequestHandler<ChangeShowCaseImageCommandRequest, ChangeShowCaseImageCommandResponse>
    {
        private readonly IProductImageFileReadRepository _productReadRepository;
        private readonly IProductImageFileWriteRepository _productWriteRepository;
        public ChangeShowCaseImageCommandHandler(IProductImageFileReadRepository productReadRepository, IProductImageFileWriteRepository productWriteRepository)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
        }

        public async Task<ChangeShowCaseImageCommandResponse> Handle(ChangeShowCaseImageCommandRequest request, CancellationToken cancellationToken)
        {

            var query = _productWriteRepository.Table.Include(x => x.Products).SelectMany(x => x.Products, (pif, p) => new
            {
                p,
                pif
            });

            var data = await query.FirstOrDefaultAsync(x => x.p.Id == Guid.Parse(request.ProductId) && x.pif.ShowCase);
            if (data != null)
            {
                data.pif.ShowCase = false;
            }

            var image = await query.FirstOrDefaultAsync(x => x.pif.Id == Guid.Parse(request.ImageId));
            if (image != null)
            {
                image.pif.ShowCase = false;
            }
            await _productWriteRepository.SaveChange();
            return new();

        }
    }
}
