public class CalculoJurosRequest {
    public int Valor { get; set; }
    public DateOnly DataVencimento { get; set; }
}

public class CalculoJurosResponse {
    public int ValorOriginal { get; set; }
    public int DiasAtrasados { get; set; }
    public decimal ValorJuros { get; set; }
    public decimal ValorTotal { get; set; }
}