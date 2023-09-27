using eTradeBackend.Application.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTradeBackend.Application.Features.Commands.Order.CompletedOrder
{
    public class CompletedOrderCommandHandler : IRequestHandler<CompletedOrderCommandRequest, CompletedOrderCommandResponse>
    {
        private readonly IOrderService _orderService;
        private readonly IMailService _mailService;

        public CompletedOrderCommandHandler(IMailService mailService, IOrderService orderService)
        {
            _mailService = mailService;
            _orderService = orderService;
        }

        public async Task<CompletedOrderCommandResponse> Handle(CompletedOrderCommandRequest request, CancellationToken cancellationToken)
        {
            await _orderService.CompletedOrderAsync(request.OrderId);
            //await _mailService.SendMailAsync()  // appsettings te  mail adresleri eklenerek sendMail adresine gönderilebilir, şuan için boş bırakılacaktır.
            return new();
        }
    }
}
