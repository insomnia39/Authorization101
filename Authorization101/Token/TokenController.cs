using Microsoft.IdentityModel.Tokens;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Authorization101.Token
{
    public class TokenController
    {
        public const string secret = "this-is-secret-i-swear";
        public static string GenerateToken(string userId)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.PrimarySid, userId),
                new Claim("custom", "CustomClaim"),
            };
            var token = new JwtSecurityToken(
                issuer: "insomnia39", 
                audience: "f39", 
                claims: claims, 
                expires: DateTime.Now.AddMinutes(5), 
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
