using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTradeBackend.Application.Features.Commands.ProductImageFile.UploadProductImage
{
    public class UpdaloadProductImageCommandRequest : IRequest<UpdaloadProductImageCommandResponse>
    {
        public string Id { get; set; }
        public IFormFileCollection FormFiles { get; set; }
    }
}
