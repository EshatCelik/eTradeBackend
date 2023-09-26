using eTradeBackend.Application.DTOs.User;
using eTradeBackend.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTradeBackend.Application.Services
{
    public interface IUserService
    {
        Task<CreateUserResponse> CreateUserAsync(CreateUserDto model);
        Task UpdateRefreshTokenAsync(AppUser user, string refreshToken, DateTime accessTokenTime, int addOnAccessTokenDateTime);
        Task UpdatePosswordAsync(string userId, string resetToken, string newPassword);
        Task<List<ListUser>> GetAllUsersAsync(int page, int pageSize);
        public int TotalUsersCount { get; }
        Task AssignRoleToUserAsync(string userId, string[] roles);
        Task<List<string>> GetRolesToUserAsync(string userIdOrName);
        Task<bool> HasRolePermissiontoEndpointAsync(string userName, string code);
    }
}
