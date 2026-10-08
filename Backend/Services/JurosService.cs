public class JurosService
{
    public CalculoJurosResponse CalcularJuros(CalculoJurosRequest request)
    {
        DateOnly dataAtual = DateOnly.FromDateTime(DateTime.Today);
        int diasVencidos = dataAtual.DayNumber - request.DataVencimento.DayNumber;
        if (diasVencidos <= 0)
        {
            return new CalculoJurosResponse
            {
                ValorOriginal = request.Valor,
                DiasAtrasados = 0,
                ValorJuros = 0,
                ValorTotal = request.Valor,
            };
        }

        decimal jurosPorDia = request.Valor * 0.025m;
        decimal jurosTotal = diasVencidos * jurosPorDia;

        return new CalculoJurosResponse
        {
            ValorOriginal = request.Valor,
            DiasAtrasados = diasVencidos,
            ValorJuros = jurosTotal,
            ValorTotal = request.Valor + jurosTotal,
        };
    }
}