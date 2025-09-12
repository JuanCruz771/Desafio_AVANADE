using Desafio_e_commerce_AVANADE_Vendas.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Desafio_e_commerce_AVANADE_Vendas.Services
{
    public class Token_Service
    {
        private readonly IConfiguration _config;

        public Token_Service(IConfiguration config)
        {
            _config = config;
        }

        public string GenerateToken(Usuario user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config["Jwt:Key"]);

            var claims = new[]
            {
            new Claim(ClaimTypes.Name, user.Nome ?? ""),
            new Claim(ClaimTypes.Email, user.Email ?? ""),
            new Claim("TipoUsuario", user.Tipo.ToString())
        };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(2),
                Issuer = "API_Vendas",
                Audience = "APIs_Parceiras",
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature
                )
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
