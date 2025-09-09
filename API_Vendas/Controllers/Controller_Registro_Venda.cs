using Desafio_e_commerce_AVANADE_Vendas.DAO;
using Desafio_e_commerce_AVANADE_Vendas.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Desafio_e_commerce_AVANADE_Vendas.Controllers
{

    [ApiController]
    [Route("/Registro_Venda")]
    public class Controller_Registro_Venda : ControllerBase
    {
        private readonly Context _context;
        private readonly IConfiguration _config;

        public Controller_Registro_Venda(Context context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        [Authorize]
        [HttpGet("Buscar_Registro_Venda_Id")]
        public IActionResult Buscar_Registro_Venda_Id(int id)
        {
            // TODO: Buscar o Id no banco utilizando o EF
            var registro = _context.Registro_Venda.Find(id);

            // TODO: Validar o tipo de retorno. Se não encontrar a tarefa, retornar NotFound,
            if (registro != null)
            {
                // caso contrário retornar OK com a tarefa encontrada 
                return Ok(registro);

            }
            else
            {

                return NotFound();
            }
        }

        [Authorize]
        [HttpGet("Buscar_Todos_Registro_Venda")]
        public IActionResult Buscar_Todos_Registro_Venda()
        {
            // TODO: Buscar todas as tarefas no banco utilizando o EF
            var registro = _context.Registro_Venda.ToList();
            return Ok(registro);
        }

        [Authorize]
        [HttpPost("Adicionar_Registro_Venda")]
        public IActionResult Adicionar_Registro_Venda(Registro_Vendas registro)
        {
            // TODO: Adicionar a tarefa recebida no EF e salvar as mudanças (save changes)
            _context.Registro_Venda.Add(registro);
            _context.SaveChanges();
            return CreatedAtAction(nameof(Buscar_Registro_Venda_Id), new { id = registro.Id }, registro);
        }



       
    }
}
