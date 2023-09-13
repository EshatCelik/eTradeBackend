using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTradeBackend.Application.Services.Authentication
{
    public interface IExternalAuthentication
    {
        Task<DTOs.Token> FacebookLoginAsync(string authToken);
        Task<DTOs.Token> GoogleLoginAsync(string idToken);
        Task<DTOs.Token> GoogleV2LoginAsync(string code);
    }
}
