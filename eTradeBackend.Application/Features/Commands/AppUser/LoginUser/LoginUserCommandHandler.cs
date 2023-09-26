using eTradeBackend.Application.DTOs;
using eTradeBackend.Application.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTradeBackend.Application.Features.Commands.AppUser.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, LoginUserCommandResponse>
    {
        private readonly IAuthService _authService;

        public LoginUserCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
        {
            var response = await _authService.LoginAsyn(request.UserNameorEmail, request.UserPassword);
            if (response == null)
                return new LoginUserErrorCommandResponse()
                {
                    Message = "response is null"
                };

            return new LoginUserSuccessCommandResponse()
            {
                Token = response
            };
        }
    }
}
