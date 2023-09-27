using eTradeBackend.Application.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTradeBackend.Application.Features.Commands.Basket.UpdateItemToBasket
{
    public class UpdateItemToBasketCommandHandler : IRequestHandler<UpdateItemToBasketCommandRequest, UpdateItemToBasketCommandResponse>
    {
        private readonly IBasketService _basketService;

        public UpdateItemToBasketCommandHandler(IBasketService basketService)
        {
            _basketService = basketService;
        }

        public async Task<UpdateItemToBasketCommandResponse> Handle(UpdateItemToBasketCommandRequest request, CancellationToken cancellationToken)
        {
            await _basketService.UpdateQuantityAsync(new DTOs.Basket.UpdateBasketDto()
            {
                BasketItemId = request.BasketItemId,
                Quantity = request.Quantity,
            });
            return new();
        }
    }
}
