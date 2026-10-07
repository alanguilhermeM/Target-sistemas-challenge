using System.Text.Json;

public class EstoqueService
{
    private readonly IWebHostEnvironment _environment;

    public EstoqueService(IWebHostEnvironment environment)
    {
        _environment = environment;
    }

    public List<ProdutoEstoque> CarregarEstoque()
    {
        var caminho = Path.Combine(
            _environment.ContentRootPath,
            "Data",
            "estoque.json"
        );

        var json = File.ReadAllText(caminho);

        var dados = JsonSerializer.Deserialize<ProdutoEstoqueRequest>(
            json,
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            }
        ) ?? throw new InvalidOperationException("Não foi possível carregar o estoque.");

        return dados.Estoque;
    }

    public void SalvarEstoque(List<ProdutoEstoque> produtos)
    {
        var caminho = Path.Combine(
            _environment.ContentRootPath,
            "Data",
            "estoque.json"
        );

        var dados = new ProdutoEstoqueRequest
        {
            Estoque = produtos
        };

        var json = JsonSerializer.Serialize(
            dados,
            new JsonSerializerOptions
            {
                WriteIndented = true
            }
        );

        File.WriteAllText(caminho, json);
    }

    public ProdutoEstoque BuscarProduto(List<ProdutoEstoque> produtos, int codigoProduto)
    {
        var produto = produtos.FirstOrDefault(
            produto => produto.CodigoProduto == codigoProduto
        ) ?? throw new KeyNotFoundException(
            $"O código do produto {codigoProduto} não foi encontrado no estoque."
        );

        return produto;
    }

    public int MovimentacaoDeEstoque(MovimentacaoEstoque movimentacao, ProdutoEstoque produto)
    {
        if (movimentacao.Tipo == "Entrada")
        {
            return produto.Estoque += movimentacao.Quantidade;
        }
        else if (movimentacao.Tipo == "Saída" && movimentacao.Quantidade <= produto.Estoque)
        {
            return produto.Estoque -= movimentacao.Quantidade;
        }
        else if (movimentacao.Tipo == "Saída" && movimentacao.Quantidade > produto.Estoque)
        {
            throw new InvalidOperationException("Quantidade solicitada para saída maior que o estoque disponível.");
        }
        else
        {
            throw new ArgumentException($"O tipo de movimentação {movimentacao.Tipo} não existe no sistema");
        }
    }
}

// Movimentação 1
// Produto: 101
// Tipo: Entrada
// Quantidade: 20
// Descrição: "Compra de mercadoria"