public class ComissaoService
{
    public IEnumerable<IGrouping<string, Venda>> AgruparPorVendedor(List<Venda> vendas)
    {
        return vendas.GroupBy(venda => venda.Vendedor);
    }
    public decimal CalcularComissao(IGrouping<string, Venda> grupo)
    {
        return grupo.Sum(venda =>
        {
            if (venda.Valor >= 100 && venda.Valor < 500)
            {
                return venda.Valor * 0.01m;
            }
            else if (venda.Valor >= 500)
            {
                return venda.Valor * 0.05m;
            }

            return 0;
        });
    }
}
