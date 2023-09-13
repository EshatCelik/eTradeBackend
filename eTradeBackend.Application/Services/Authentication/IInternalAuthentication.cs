using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTradeBackend.Application.Services.Authentication
{
    public interface IInternalAuthentication
    {
        Task<DTOs.Token> LoginAsyn(string username, string password);
        Task<DTOs.Token> RefreshTokenLoginAsync(string refreshToken);
    }
}
