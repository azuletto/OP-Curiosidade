using Application.Auth.Interfaces;
using Application.Output.DTO;
using Microsoft.IdentityModel.Tokens;
using OpCuriosidade.Entities.PersonnelContext;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Auth
{
    public class AuthService : IAuthServices
    {
        public string GenerateToken(AdminDTO adminDTO)
        {
            var key = Encoding.UTF8.GetBytes(Config.PrivateKey);
            var handler = new JwtSecurityTokenHandler();
            var credentials = new SigningCredentials(
                new SymmetricSecurityKey(key), 
                SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = GenerateClaimsIdentity(adminDTO),
                SigningCredentials = credentials,
                Expires = DateTime.UtcNow.AddHours(8),
            };

            var token = handler.CreateToken(tokenDescriptor);
            return handler.WriteToken(token);
        }
        private static ClaimsIdentity GenerateClaimsIdentity(AdminDTO adminDTO)
        {
            var ci = new ClaimsIdentity();
            if (!string.IsNullOrEmpty(adminDTO.Name))
            {
                ci.AddClaim(new Claim(ClaimTypes.Name, adminDTO.Name));
            }
            return ci;
        }
    }
}
