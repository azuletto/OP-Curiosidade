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
                Expires = DateTime.UtcNow.AddHours(8)
            };

            var token = handler.CreateToken(tokenDescriptor);
            return handler.WriteToken(token);
        }

        private static ClaimsIdentity GenerateClaimsIdentity(AdminDTO adminDTO)
        {
            var claims = new List<Claim>();

            if (!string.IsNullOrEmpty(adminDTO.Name))
                claims.Add(new Claim(ClaimTypes.Name, adminDTO.Name));

            if (!string.IsNullOrEmpty(adminDTO.Email))
            {
                claims.Add(new Claim(ClaimTypes.NameIdentifier, adminDTO.Email));
                claims.Add(new Claim("sub", adminDTO.Email));
            }

            claims.Add(new Claim(ClaimTypes.Role, "Admin"));

            return new ClaimsIdentity(claims);
        }
        public static bool isValidToken(string token)
        {
            var key = Encoding.UTF8.GetBytes(Config.PrivateKey);
            var handler = new JwtSecurityTokenHandler();
            try
            {
                handler.ValidateToken(token, new TokenValidationParameters
                {
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
