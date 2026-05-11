using System;

namespace CadastroProduto.Services;

public interface IProdutosService
{
    public List<Produto> ObterTodos();
    public Produto ObterPorId(int Id);
    public void Adicionar(Produto novoProduto);

    public Produto Atualizar(int Id, Produto produtoAtualizado);

    public bool Remover(int Id);     
}
