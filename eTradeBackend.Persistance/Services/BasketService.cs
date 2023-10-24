using eTradeBackend.Application.DTOs.Basket;
using eTradeBackend.Application.Repositories.Basket;
using eTradeBackend.Application.Repositories.BasketItem;
using eTradeBackend.Application.Repositories.OrderRepository;
using eTradeBackend.Application.Services;
using eTradeBackend.Domain.Entities;
using eTradeBackend.Domain.Entities.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTradeBackend.Persistance.Services
{
    public class BasketService : IBasketService
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly UserManager<AppUser> _userManager;
        private readonly IOrderReadRepository _orderReadRepository;
        private readonly IBasketItemReadRepository _itemReadRepository;
        private readonly IBasketItemWriteRepository _itemWriteRepository;
        private readonly IBasketWriteRepository _basketWriteRepository;
        private readonly IBasketReadRepository _basketReadRepository;

        public BasketService(IHttpContextAccessor contextAccessor,
            UserManager<AppUser> userManager,
            IOrderReadRepository orderReadRepository,
            IBasketItemReadRepository itemReadRepository,
            IBasketItemWriteRepository itemWriteRepository,
            IBasketWriteRepository basketWriteRepository,
            IBasketReadRepository basketReadRepository)
        {
            _contextAccessor = contextAccessor;
            _userManager = userManager;
            _orderReadRepository = orderReadRepository;
            _itemReadRepository = itemReadRepository;
            _itemWriteRepository = itemWriteRepository;
            _basketReadRepository = basketReadRepository;
            _basketWriteRepository = basketWriteRepository;
        }

        public Basket? GetUserActiveBasket => throw new NotImplementedException();

        public Task AddItemToBAsketAsync(CreateBasketDto baskteItem)
        {
            throw new NotImplementedException();
        }

        public Task<List<BasketItem>> GetBasketItemsAsync()
        {
            throw new NotImplementedException();
        }

        public Task RemoveBasketItemAsync(string basketItemId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateQuantityAsync(UpdateBasketDto basketItem)
        {
            throw new NotImplementedException();
        }

        private async Task<Basket?> ContextUser()
        {
            var userName = _contextAccessor.HttpContext?.User?.Identity.Name;

            if (!string.IsNullOrEmpty(userName))
            {
                AppUser? user=await _userManager.Users
                    .Include(x=>x.Baskets)
                    .FirstOrDefaultAsync(x=>x.UserName == userName);

                var _basket = from basket in user?.Baskets
                              join order in _orderReadRepository.Table
                              on basket.Id equals order.Id into BasketOrders
                              from order in BasketOrders.DefaultIfEmpty()
                              select new
                              {
                                  Basket = basket,
                                  Order = order
                              };

                Basket? targetBasket = null;
                if (_basket.Any(x=>x.Order is null))
                {
                    targetBasket = _basket.FirstOrDefault(x => x.Order is null)?.Basket;
                }
                else
                {

                    targetBasket = new();
                    user.Baskets.Add(targetBasket);
                }

                await _basketWriteRepository.SaveChange();
                return targetBasket;
            }

            throw new Exception("Beklenmedik bir sorun ile karşılaşıldı ...");
        }
    }
}
