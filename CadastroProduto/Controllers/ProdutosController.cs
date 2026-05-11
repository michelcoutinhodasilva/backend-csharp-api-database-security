using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CadastroProduto.Services;

namespace CadastroProduto.Controllers
{
    [Route("api/[controller]")]
    [ApiController] 
    [Tags("Produtos API")]
    public class ProdutosController : ControllerBase
    {
        private IProdutosService produtosService = new ProdutosService();

        [HttpGet]
        public ActionResult<List<Produto>> Get()
        {
            return Ok(produtosService.ObterTodos());
        }

        [HttpGet("{Id}")]
        public ActionResult<Produto> GetbyId(int Id)
        {
            var produto = produtosService.ObterPorId(Id);

            if (produto is null)
             {
                return NotFound($"Produto com ID {Id} não encontrado");
             }
            return Ok(produto);
        } 
        [HttpPost]
        public ActionResult Post(Produto novoProduto)
        {
            produtosService.Adicionar(novoProduto);
            return Created();
        }

        [HttpPut("{Id}")]
        public ActionResult<Produto> Put(int Id, Produto produtoAtualizado)
        {
            var produto = produtosService.Atualizar(Id, produtoAtualizado);
            if (produto == null)
            {
                return NotFound($"Produto com ID {Id} não encontrado");
            }

            return Ok(produto);
        }
        [HttpDelete("{Id}")]
        public ActionResult Delete(int Id)
        {
            var deletou = produtosService.Remover(Id);
            if (deletou == false)
            {
                return NotFound($"Produto com ID {Id} não encontrado");
            }
            return NoContent();
        }
    }
}
