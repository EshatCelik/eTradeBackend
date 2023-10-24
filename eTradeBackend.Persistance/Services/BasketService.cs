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

        public async Task AddItemToBAsketAsync(CreateBasketDto baskteItem)
        {
            Basket? basket = await ContextUser();
            if (basket != null)
            {
                BasketItem currentBasketItem = await _itemReadRepository.GetSingleAsync(x => x.BasketId == basket.Id && x.ProductId == Guid.Parse(baskteItem.ProductId));
                if (currentBasketItem != null)
                {
                    currentBasketItem.Quantity += baskteItem.Quantity;
                }
                else
                {
                    await _itemWriteRepository.AddAsync(new()
                    {
                        BasketId = basket.Id,
                        ProductId = Guid.Parse(baskteItem.ProductId),
                        Quantity = baskteItem.Quantity,
                    });
                }
                await _basketWriteRepository.SaveChange();
            }
        }

        public async Task<List<BasketItem>> GetBasketItemsAsync()
        {
            Basket? basket = await ContextUser();
            Basket? result = await _basketReadRepository.Table
                .Include(x => x.BasketItems)
                .ThenInclude(x => x.Product)
                .ThenInclude(x => x.ProductImageFiles)
                .FirstOrDefaultAsync(y => y.Id == basket.Id);
            return result != null ? result.BasketItems.ToList() : null;
        }

        public async Task RemoveBasketItemAsync(string basketItemId)
        {
            BasketItem item = await _itemReadRepository.GetByIdAsync(basketItemId);
            if (item != null)
            {
                _itemWriteRepository.Remove(item);
                await _basketWriteRepository.SaveChange();
            }
        }

        public async Task UpdateQuantityAsync(UpdateBasketDto basketItem)
        {
            BasketItem item = await _itemReadRepository.GetByIdAsync(basketItem.BasketItemId);
            if (item != null)
            {
                item.Quantity = basketItem.Quantity;
                await _basketWriteRepository.SaveChange();
            }
        }

        private async Task<Basket?> ContextUser()
        {
            var userName = _contextAccessor.HttpContext?.User?.Identity.Name;

            if (!string.IsNullOrEmpty(userName))
            {
                AppUser? user = await _userManager.Users
                    .Include(x => x.Baskets)
                    .FirstOrDefaultAsync(x => x.UserName == userName);

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
                if (_basket.Any(x => x.Order is null))
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
