using eTradeBackend.Application.DTOs.Basket;
using eTradeBackend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTradeBackend.Application.Services
{
    public interface IBasketService
    {
        Task<List<BasketItem>> GetBasketItemsAsync();
        Task AddItemToBAsketAsync(CreateBasketDto baskteItem);
        Task UpdateQuantityAsync(UpdateBasketDto basketItem);
        Task RemoveBasketItemAsync(string  basketItemId);
        Basket? GetUserActiveBasket { get; }
    }
}
