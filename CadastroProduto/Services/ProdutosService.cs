using System;

namespace CadastroProduto.Services;

public class ProdutosService : IProdutosService
{
    private static List<Produto> produtos = new List<Produto>()
    {
        new Produto { Id = 1, Nome = "Camiseta Preta", Preco = 99.99m, Estoque = 10 },
        new Produto { Id = 2, Nome = "Calça Jeans", Preco = 119.99m, Estoque = 5 },
        new Produto { Id = 3, Nome = "Blusa de frio", Preco = 250.99m, Estoque = 30 }
    };
    public List<Produto> ObterTodos()
    {
        return produtos;
    }
    public Produto ObterPorId(int Id)
    {
        return produtos.FirstOrDefault(x => x.Id == Id);
    }
    public void Adicionar(Produto novoProduto)
    {
        produtos.Add(novoProduto);
    }
    public Produto Atualizar(int Id, Produto produtoAtualizado)
    {
        var produto = produtos.FirstOrDefault(x => x.Id == Id);
        if (produto != null)
        {
            produto.Nome = produtoAtualizado.Nome;
            produto.Preco = produtoAtualizado.Preco;
            produto.Estoque = produtoAtualizado.Estoque;
        }
        return produto;
    }
    public bool Remover(int Id)
    {
        var produto = produtos.FirstOrDefault(x => x.Id == Id);
        if (produto is null)
        {
            return false;
        }
        produtos.Remove(produto);
        return true;
    }
}   
