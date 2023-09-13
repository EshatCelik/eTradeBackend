using eTradeBackend.Application.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTradeBackend.Application.Features.Queries.AppUser.GetAllUser
{
    public class GetAllUserQueryHandler : IRequestHandler<GetAllUsersQueryRequest, GetAllUserQueryResponse>
    {
        private readonly IUserService _userService;
        public GetAllUserQueryHandler(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<GetAllUserQueryResponse> Handle(GetAllUsersQueryRequest request, CancellationToken cancellationToken)
        {
            var result = await _userService.GetAllUserAsync(request.Page, request.Size);
            return new()
            {
                Users = result,
                TotalUserCount = _userService.TotalUsersCount
            };
        }
    }
}
