using eTradeBackend.Application.Abstract.Token;
using eTradeBackend.Domain.Entities.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace eTradeBackend.Infrastructure.Services.Token
{
    public class TokenHandler : ITokenHandler
    {
        private readonly IConfiguration _config;

        public TokenHandler(IConfiguration config)
        {
            _config = config;
        }

        public Application.DTOs.Token CreateAccessToken(AppUser user, int tokenExp = 30)
        {
            Application.DTOs.Token token = new Application.DTOs.Token();

            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Token:SecurityKey"]));

            SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            token.Expiration = DateTime.UtcNow.AddMinutes(tokenExp);
            JwtSecurityToken securityToken = new JwtSecurityToken
                (
                audience: _config["Token:Audience"],
                issuer: _config["Token:Issuer"],
                expires: token.Expiration,
                notBefore: DateTime.Now,
                signingCredentials: signingCredentials,
                claims: new List<Claim>() { new(ClaimTypes.Name, user.UserName) }
                );

            JwtSecurityTokenHandler securityTokenHandler = new JwtSecurityTokenHandler();
            token.AccessToken = securityTokenHandler.WriteToken(securityToken);
            return token;


        }

        public string CreateRefreshToken()
        {
            byte[] number = new byte[32];
            using RandomNumberGenerator generator = RandomNumberGenerator.Create();
            generator.GetBytes(number);
            return Convert.ToBase64String(number);
        }
    }
}
