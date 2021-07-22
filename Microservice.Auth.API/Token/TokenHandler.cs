using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Microservice.Auth.API.Token
{
    public static class TokenHandler
    {
        public static IConfiguration _configuration;
        public static dynamic CreateAccessToken()
        {
            SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["JWT:Security"]));
            DateTime now = DateTime.UtcNow;
            JwtSecurityToken jwt = new JwtSecurityToken(
                     issuer: _configuration["JWT:Issuer"],
                     audience: _configuration["JWT:Audience"],
                     claims: new List<Claim> {
                      new Claim(ClaimTypes.Name, "mutlu")
                     },
                     notBefore: now,
                     expires: now.Add(TimeSpan.FromMinutes(2)),
                     signingCredentials: new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256)
                 );
            return new
            {
                AccessToken = new JwtSecurityTokenHandler().WriteToken(jwt),
                Expires = TimeSpan.FromMinutes(2).TotalSeconds
            };
        }
    }
}
