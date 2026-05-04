var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi



builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var produtos = new List<Produto>()
{
    new Produto { Id = 1, Nome = "Camiseta Preta", Preco = 99.99m, Estoque = 10 },
    new Produto { Id = 2, Nome = "Calça Jeans", Preco = 119.99m, Estoque = 5 },
    new Produto { Id = 3, Nome = "Blusa de frio", Preco = 250.99m, Estoque = 30 }
};

app.MapGet("/produtos", () =>{ 
    return produtos;
});

app.MapGet("/produtos/{Id}",(int Id) => {
    var produto = produtos.FirstOrDefault(x => x.Id == Id);
    return produto is not null 
    ?Results.Ok(produto)
    :Results.NotFound($"Produto com ID {Id} não encontrado");
});

app.MapPost("/produtos",(Produto novoProduto) => {
    produtos.Add(novoProduto);
    return Results.Created();
    
});
app.MapPut("/produtos/{Id}", (int Id, Produto produtoAtualizado) =>
{
    var produto = produtos.FirstOrDefault(x => x.Id == Id);
    if (produto == null ){
        return Results.NotFound($"Produto com ID {Id} não encontrado");
    }
    produto.Nome = produtoAtualizado.Nome;
    produto.Preco = produtoAtualizado.Preco;
    produto.Estoque = produtoAtualizado.Estoque;
    return Results.Ok(produto);     
});

app.MapDelete("/produtos/{Id}", (int Id) =>
{
    var produto = produtos.FirstOrDefault(x => x.Id == Id);
    if (produto == null)
    {
        return Results.NotFound($"Produto com ID {Id} não encontrado");
    }
    produtos.Remove(produto);
    return Results.NoContent();
});
app.Run();

class Produto
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public decimal Preco { get; set; }
    public int Estoque { get; set; }
}