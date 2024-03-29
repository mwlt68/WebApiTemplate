﻿using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Token.Jwt
{
    public class JwtService : IJwtService
    {
        private readonly JwtSettings jwtSettings;
        public JwtService(IOptions<JwtSettings> jwtSettings)
        {
            this.jwtSettings = jwtSettings.Value;
        }
        public String CreateToken(int userId)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[] {
                new Claim(ClaimTypes.NameIdentifier, Convert.ToString(userId)),
                };
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(jwtSettings.ValidateLifetime),
                signingCredentials: credentials,
                issuer: jwtSettings.ValidIssuer,
                audience: jwtSettings.ValidAudience
                );

            string tokenStr = new JwtSecurityTokenHandler().WriteToken(token);
            return tokenStr;
        }
    }
}
