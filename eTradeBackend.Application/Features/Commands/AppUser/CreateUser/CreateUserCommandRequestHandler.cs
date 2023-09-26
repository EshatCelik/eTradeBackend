using eTradeBackend.Application.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTradeBackend.Application.Features.Commands.AppUser.CreateUser
{
    public class CreateUserCommandRequestHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
    {
        private readonly IUserService _userService;

        public CreateUserCommandRequestHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            var response = await _userService.CreateUserAsync(new DTOs.User.CreateUserDto()
            {
                Email = request.Email,
                Fullname = request.FullName,
                Password = request.Password,
                PasswordConfirm = request.PasswordConfirm,
                Username = request.UserName
            });

            return new()
            {
                Message = response.Message,
                Success = response.Successed
            };
        }
    }
}
