using eTradeBackend.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTradeBackend.Application.Abstract.Token
{
    public interface ITokenHandler
    {
        DTOs.Token CreateAccessToken(AppUser user, int tokenExp = 30);
        string CreateRefreshToken();
    }
}
