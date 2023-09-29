using eTradeBackend.Application.Repositories.ProductRepository;
using eTradeBackend.Application.Services;
using eTradeBackend.Application.Services.Hubs;
using Google.Apis.Logging;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace eTradeBackend.Application.Features.Commands.Product.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, CreateProductCommandResponse>
    {
        private readonly IProductWriteRepository _repository;
        private readonly ILogger<CreateProductCommandHandler> _logger;
        private readonly IProductHubService _productHubService;
        public CreateProductCommandHandler(IProductWriteRepository repository, ILogger<CreateProductCommandHandler> logger, IProductHubService productHubService)
        {
            _repository = repository;
            _logger = logger;
            _productHubService = productHubService;
        }

        public async Task<CreateProductCommandResponse> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            await _repository.AddAsync(new Domain.Entities.Product()
            {
                Name = request.Name,
                Stock = request.Stock,
                Price = request.Price
            });

            await _repository.SaveChange();

            _logger.LogInformation(JsonSerializer.Serialize(request), "Ürün Eklendi");

            await _productHubService.ProductAddedMessageAsync($"{request.Name} adlı ürün eklendi    ");
            return new();
        }
    }
}
