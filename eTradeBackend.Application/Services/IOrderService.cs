using eTradeBackend.Application.DTOs.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTradeBackend.Application.Services
{
    public interface IOrderService
    {
        Task CreateOrderAsync(CreateOrderDto createOrderDto);
        Task<OrderListDto> GetAllOrderAsync(int page, int pageSize);
        Task<SingleOrder> GetOrderByIdAsync(string id);
        Task CompletedOrderAsync(string id);
    }
}
