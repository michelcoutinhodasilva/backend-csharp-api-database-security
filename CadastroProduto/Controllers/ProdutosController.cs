using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CadastroProduto.Controllers
{
    [Route("api/[controller]")]
    [ApiController] 
    [Tags("Produtos API")]
    public class ProdutosController : ControllerBase
    {
        private static List<Produto> produtos = new List<Produto>()
        {
            new Produto { Id = 1, Nome = "Camiseta Preta", Preco = 99.99m, Estoque = 10 },
            new Produto { Id = 2, Nome = "Calça Jeans", Preco = 119.99m, Estoque = 5 },
            new Produto { Id = 3, Nome = "Blusa de frio", Preco = 250.99m, Estoque = 30 }
        };
        [HttpGet]
        public ActionResult<List<Produto>> Get()
        {
            return Ok(produtos);
        }

        [HttpGet("{Id}")]
        public ActionResult<Produto> GetbyId(int Id)
        {
            var produto = produtos.FirstOrDefault(x => x.Id == Id);

            if (produto is null)
             {
                return NotFound($"Produto com ID {Id} não encontrado");
             }
            return Ok(produto);
        } 
        [HttpPost]
        public ActionResult Post(Produto novoProduto)
        {
            produtos.Add(novoProduto);
            return Created();
        }

        [HttpPut("{Id}")]
        public ActionResult<Produto> Put(int Id, Produto produtoAtualizado)
        {
            var produto = produtos.FirstOrDefault(x => x.Id == Id);
            if (produto == null)
            {
                return NotFound($"Produto com ID {Id} não encontrado");
            }
            produto.Nome = produtoAtualizado.Nome;
            produto.Preco = produtoAtualizado.Preco;
            produto.Estoque = produtoAtualizado.Estoque;
            return Ok(produto);
        }
        [HttpDelete("{Id}")]
        public ActionResult Delete(int Id)
        {
            var produto = produtos.FirstOrDefault(x => x.Id == Id);
            if (produto == null)
            {
                return NotFound($"Produto com ID {Id} não encontrado");
            }
            produtos.Remove(produto);
            return NoContent();
        }
    }
}
