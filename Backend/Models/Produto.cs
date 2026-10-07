public class ProdutoEstoque
{
    public int CodigoProduto { get; set; }
    public string DescricaoProduto { get; set; }
    public int Estoque { get; set; }
}

public class ProdutoEstoqueRequest
{
    public List<ProdutoEstoque> Estoque { get; set; }
}