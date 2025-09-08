using Desafio_e_commerce_AVANADE_Estoque.DAO;
using Desafio_e_commerce_AVANADE_Estoque.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Desafio_e_commerce_AVANADE_Estoque.Controllers
{
    [ApiController]
    [Route("/Usuario")]
    public class Controller_Usuario : ControllerBase
    {
        private readonly Context _context;
        private readonly IConfiguration _config;

        public Controller_Usuario(Context context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        [Authorize]
        [HttpGet("Buscar_Usuario_Id")]
        public IActionResult Buscar_Usuario_Id(int id)
        {
            // TODO: Buscar o Id no banco utilizando o EF
            var usuario = _context.Usuarios.Find(id);

            // TODO: Validar o tipo de retorno. Se não encontrar a tarefa, retornar NotFound,
            if (usuario != null)
            {
                // caso contrário retornar OK com a tarefa encontrada 
                return Ok(usuario);

            }
            else
            {

                return NotFound();
            }
        }

        [Authorize]
        [HttpGet("Buscar_Todos_Usuario")]
        public IActionResult Buscar_Todos_Usuario()
        {
            // TODO: Buscar todas as tarefas no banco utilizando o EF
            var usuarios = _context.Usuarios.ToList();
            return Ok(usuarios);
        }

        [HttpPost("Adicionar_Usuario")]
        public IActionResult Adicionar_Usuario(Cadastro_Usuario usuario)
        {
            // TODO: Adicionar a tarefa recebida no EF e salvar as mudanças (save changes)
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
            return CreatedAtAction(nameof(Buscar_Usuario_Id), new { id = usuario.id }, usuario);
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] Cadastro_Usuario login)
        {
            var user = _context.Usuarios
                .FirstOrDefault(u => u.Senha == login.Senha && (u.Nome == login.Nome || u.Email == login.Email));

            if (user == null) return Unauthorized("Usuário ou senha inválidos");

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config["Jwt:Key"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                new Claim(ClaimTypes.Name, user.Nome),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim("TipoUsuario", user.Tipo.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                Issuer = _config["Jwt:Issuer"],
                Audience = _config["Jwt:Audience"],
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return Ok(new { Token = tokenString });
        }
    }
}
