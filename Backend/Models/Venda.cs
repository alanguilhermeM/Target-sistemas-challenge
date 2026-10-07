public class Venda
{
    public string Vendedor { get; set; }
    public decimal Valor { get; set; }
}

public class VendasRequest
{
    public List<Venda> Vendas { get; set; }
}

public class ResultadoComissao
{
    public string Vendedor { get; set; }
    public decimal TotalComissao { get; set; }
}