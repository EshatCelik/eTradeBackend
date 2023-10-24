using eTradeBackend.Application.DTOs.Order;
using eTradeBackend.Application.Repositories.CompletedItem;
using eTradeBackend.Application.Repositories.OrderRepository;
using eTradeBackend.Application.Services;
using eTradeBackend.Infrastructure.Operations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTradeBackend.Persistance.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderWriteRepository _orderWriteRepository;
        private readonly IOrderReadRepository _orderReadRepository;
        private readonly ICompletedOrderReadRepository _completedReadOrder;
        private readonly ICompletedOrderWriteRepository _completedWriteOrder;
        private readonly IMailService _mailService;

        public OrderService(IOrderWriteRepository orderWriteRepository,
            IOrderReadRepository orderReadRepository, 
            ICompletedOrderReadRepository completedReadOrder, 
            ICompletedOrderWriteRepository completedWriteOrder, 
            IMailService mailService)
        {
            _orderWriteRepository = orderWriteRepository;
            _orderReadRepository = orderReadRepository;
            _completedReadOrder = completedReadOrder;
            _completedWriteOrder = completedWriteOrder;
            _mailService = mailService;
        }

        public async Task CreateOrderAsync(CreateOrderDto createOrderDto)
        {
            await _orderWriteRepository.AddAsync(new Domain.Entities.Order()
            {
                Address = createOrderDto.Address,
                Description = createOrderDto.Description,
                Id = Guid.NewGuid(),
                OrderCode = RandomAlphaNumeric.RandomAlphaNumericToString()
            });
            await _orderWriteRepository.SaveChange();
        }


        public async Task<OrderListDto> GetAllOrderAsync(int page, int pageSize)
        {
            var totalCount = _orderReadRepository.Table.Count();

            var query = _orderReadRepository.Table
                .Include(x => x.Basket)
                .ThenInclude(x => x.AppUser)
                .Include(x => x.Basket)
                .ThenInclude(x => x.BasketItems)
                .ThenInclude(x => x.Product);

            var data = query.Skip(page*pageSize).Take(pageSize);

            var result = (from order in data
                          join copletedOrder in _completedReadOrder.Table
                          on order.Id equals copletedOrder.OrderId into co
                          from _co in co.DefaultIfEmpty()
                          select new OrderDto()
                          {
                              Id = order.Id.ToString(),
                              UserName = order.Basket.AppUser.FullName,
                              OrderCode = order.OrderCode,
                              CreateDate = order.CreateDate,
                              TotalPrice = order.Basket.BasketItems.Sum(x => x.Product.Price),
                              Completed = _co != null
                          }).ToListAsync();

            return new()
            {
                Orders = await result,
                TotalCount = totalCount
            };

        }
        public async Task<SingleOrder> GetOrderByIdAsync(string id)
        {
            var order=await _orderReadRepository.Table
                .Include(x=>x.Basket)
                .ThenInclude(x=>x.BasketItems)
                .ThenInclude(x=>x.Product)
                .FirstOrDefaultAsync(x=>x.Id==Guid.Parse(id));

            return new()
            {
                Id = order.Id.ToString(),
                BasketItems = order.Basket.BasketItems.Select(bi => new
                {
                    bi.Product.Name,
                    bi.Product.Price,
                    bi.Quantity
                }).ToList(),
                Address = order.Address,
                CreateDate = order.CreateDate,
                Description = order.Description,
                OrderCode = order.OrderCode

            };
        }
        public async Task CompletedOrderAsync(string id)
        {
            var order=await _orderReadRepository.Table
                .Include(x=>x.Basket)
                .ThenInclude(x=>x.AppUser)
                .FirstOrDefaultAsync(x=>x.Id==Guid.Parse(id));

            if(order is not null)
            {
                await _completedWriteOrder.AddAsync(new Domain.Entities.CompletedOrder() { Id =Guid.Parse(id) });
                var result = await _completedWriteOrder.SaveChange()>0;
                if (result)
                    await _mailService.SendCompletedOrderMailAsync(order.Basket.AppUser.Email, order.OrderCode, order.CreateDate, order.Basket.AppUser.FullName);
            }
        }

    }
}
