using Desafio_e_commerce_AVANADE_Vendas.DAO;
using Desafio_e_commerce_AVANADE_Vendas.Models;
using Desafio_e_commerce_AVANADE_Vendas.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Desafio_e_commerce_AVANADE_Vendas.Controllers
{
    [ApiController]
    [Route("/Usuario")]
    public class Controller_Usuario : ControllerBase
    {
        private readonly Context _context;
        private readonly IConfiguration _config;
        private readonly Token_Service _tokenService;

        public Controller_Usuario(Context context, IConfiguration config, Token_Service tokenService)
        {
            _context = context;
            _config = config;
            _tokenService = tokenService;
        }

        [Authorize]
        [HttpGet("Buscar_Usuario_Id")]
        public IActionResult Buscar_Usuario_Id(int id)
        {
            // TODO: Buscar o Id no banco utilizando o EF
            var usuario = _context.Usuario.Find(id);

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
            var usuarios = _context.Usuario.ToList();
            return Ok(usuarios);
        }

        [HttpPost("Adicionar_Usuario")]
        public IActionResult Adicionar_Usuario(Usuario usuario)
        {
            // TODO: Adicionar a tarefa recebida no EF e salvar as mudanças (save changes)
            _context.Usuario.Add(usuario);
            _context.SaveChanges();
            return CreatedAtAction(nameof(Buscar_Usuario_Id), new { id = usuario.Id }, usuario);
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] Usuario login)
        {
            var user = _context.Usuario
         .FirstOrDefault(u => u.Senha == login.Senha && (u.Nome == login.Nome || u.Email == login.Email));

            if (user == null)
                return Unauthorized("Usuário ou senha inválidos");

            var token = _tokenService.GenerateToken(user);

            return Ok(new { Token = token });
        }
    }
}
