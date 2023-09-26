using eTradeBackend.Application.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTradeBackend.Application.Features.Commands.AppUser.FacebookLogin
{
    public class FacebookLoginCommandRequestHandler : IRequestHandler<FacebookLoginCommandRequest, FacebookLoginCommandResponse>
    {
        private readonly IAuthService _authService;

        public FacebookLoginCommandRequestHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<FacebookLoginCommandResponse> Handle(FacebookLoginCommandRequest request, CancellationToken cancellationToken)
        {
            var response = await _authService.FacebookLoginAsync(request.AuthToken);
            return new()
            {
                Token = response
            };
        }
    }
}
