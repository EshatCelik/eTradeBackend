using eTradeBackend.Application.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTradeBackend.Application.Features.Commands.AppUser.GoogleLoginV2
{
    public class GoogleLoginCommandHandler : IRequestHandler<GoogleLoginV2CommandRequest, GoogleLoginV2CommandResponse>
    {
        private readonly IAuthService _authService;

        public GoogleLoginCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<GoogleLoginV2CommandResponse> Handle(GoogleLoginV2CommandRequest request, CancellationToken cancellationToken)
        {
            var token = await _authService.GoogleV2LoginAsync(request.Code);
            return new() { Token = token };
        }
    }
}
