using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TestTask.Application.Interfaces;
using TestTask.Domain.Entities;

namespace TestTask.Infrastructure.Services
{
    public class JWTService : IJWTService
    {
        private readonly IConfiguration _configuration;
        public JWTService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateJwtToken(Guid id, string email)
        {
            var issuer = _configuration["JWTSettings:Issuer"];
            var audience = _configuration["JWTSettings:Audience"];
            var key = _configuration["JWTSettings:SecurityKey"];
            var expiration = Convert.ToInt32(_configuration["JWTSettings:Expiration"]);

            var tokenExpiration = DateTime.UtcNow.AddMinutes(expiration);

            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Sub, _configuration["JWTSettings:Subject"]), 
            new Claim("Email", email),
            new Claim("UserId", id.ToString())
        };

            

            var keyBytes = Encoding.UTF8.GetBytes(key);
            var securityKey = new SymmetricSecurityKey(keyBytes);
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer,
                audience,
                claims,
                expires: tokenExpiration,
                signingCredentials: credentials
                );

            string tokenValue = new JwtSecurityTokenHandler().WriteToken(token);
            
            return tokenValue;
        }
    }
}
