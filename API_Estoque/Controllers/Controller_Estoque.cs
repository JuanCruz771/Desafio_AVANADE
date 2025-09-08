using Desafio_e_commerce_AVANADE_Estoque.DAO;
using Desafio_e_commerce_AVANADE_Estoque.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Desafio_e_commerce_AVANADE_Estoque.Controllers
{
    [Authorize]
    
    [ApiController]
    [Route("/Estoque")]
    public class Controller_Estoque : ControllerBase
    {
        private readonly Context _context;

        public Controller_Estoque(Context context)
        {
            _context = context;
        }

        [HttpGet("Buscar_Produto_Id")]
        public IActionResult Buscar_Produto_Id(int id)
        {
            // TODO: Buscar o Id no banco utilizando o EF
            var produto = _context.Produtos.Find(id);

            // TODO: Validar o tipo de retorno. Se não encontrar a tarefa, retornar NotFound,
            if (produto != null)
            {
                // caso contrário retornar OK com a tarefa encontrada 
                return Ok(produto);

            }
            else
            {

                return NotFound();
            }
        }

        [HttpGet("Buscar_Todos_Produto")]
        public IActionResult Buscar_Todos_Produto()
        {
            // TODO: Buscar todas as tarefas no banco utilizando o EF
            var produtos = _context.Produtos.ToList();
            return Ok(produtos);
        }

        [HttpGet("Buscar_Descricao_Produto")]
        public IActionResult Buscar_Descricao_Produto(string descricao)
        {
            // TODO: Buscar  as tarefas no banco utilizando o EF, que contenha o titulo recebido por parâmetro
            // Dica: Usar como exemplo o endpoint ObterPorData
            var produtos = _context.Produtos.Where(x => x.Descricao == descricao);

            return Ok(produtos);
        }

        [HttpGet("Buscar_Codigo_Interno_Produto")]
        public IActionResult Buscar_Codigo_Interno_Produto(string codigo_interno)
        {
            // TODO: Buscar  as tarefas no banco utilizando o EF, que contenha o titulo recebido por parâmetro
            // Dica: Usar como exemplo o endpoint ObterPorData
            var produtos = _context.Produtos.Where(x => x.Codigo_interno == codigo_interno);

            return Ok(produtos);
        }

        [HttpGet("Buscar_Preco_Produto")]
        public IActionResult Buscar_Preco_Produto(decimal preco)
        {
            // TODO: Buscar  as tarefas no banco utilizando o EF, que contenha o titulo recebido por parâmetro
            // Dica: Usar como exemplo o endpoint ObterPorData
            var produtos = _context.Produtos.Where(x => x.Preco == preco);

            return Ok(produtos);
        }

        [HttpGet("Buscar_Quantidade_Produto")]
        public IActionResult Buscar_Quantidade_Produto(decimal quantidade)
        {
            // TODO: Buscar  as tarefas no banco utilizando o EF, que contenha o titulo recebido por parâmetro
            // Dica: Usar como exemplo o endpoint ObterPorData
            var produtos = _context.Produtos.Where(x => x.Quantidade == quantidade);

            return Ok(produtos);
        }

        [HttpPost("Adicionar_Produto")]
        public IActionResult Adicionar_Produto(Estoque_Produtos produto)
        {
            // TODO: Adicionar a tarefa recebida no EF e salvar as mudanças (save changes)
            _context.Produtos.Add(produto);
            _context.SaveChanges();
            return CreatedAtAction(nameof(Buscar_Produto_Id), new { id = produto.Id }, produto);
        }

        [HttpPut("Alterar_Produto_id")]
        public IActionResult Alterar_Produto_id(int id, Estoque_Produtos produto)
        {
            var Produto_Banco = _context.Produtos.Find(id);

            if (Produto_Banco == null)
                return NotFound();

            // TODO: Atualizar as informações da variável tarefaBanco com a tarefa recebida via parâmetro
            Produto_Banco = produto;
            // TODO: Atualizar a variável tarefaBanco no EF e salvar as mudanças (save changes)
            _context.Produtos.Update(Produto_Banco);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPut("Vender_Produto_Id")]
        public IActionResult Vender_Produto_Id(int id, int quantidade_vendida)
        {
            var Produto_Banco = _context.Produtos.Find(id);

            if (Produto_Banco == null)
                return NotFound();

            // TODO: Atualizar as informações da variável tarefaBanco com a tarefa recebida via parâmetro
            Produto_Banco.Quantidade = Produto_Banco.Quantidade - quantidade_vendida;
            // TODO: Atualizar a variável tarefaBanco no EF e salvar as mudanças (save changes)
            _context.Produtos.Update(Produto_Banco);
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete("Deletar_Produto_Id")]
        public IActionResult Deletar_Produto_Id(int id)
        {
            var Produto_Banco = _context.Produtos.Find(id);

            if (Produto_Banco == null)
                return NotFound();

            // TODO: Remover a tarefa encontrada através do EF e salvar as mudanças (save changes)
            _context.Produtos.Remove(Produto_Banco);
            _context.SaveChanges();
            return NoContent();
        }


    }
}
