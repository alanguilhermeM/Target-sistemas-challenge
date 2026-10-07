using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]

public class ComissaoController : ControllerBase
{
    private readonly ComissaoService _comissaoService;

    public ComissaoController(ComissaoService comissaoService)
    {
        _comissaoService = comissaoService;
    }
    [HttpPost]
    public List<ResultadoComissao> Calcular(List<Venda> vendas)
    {
        return _comissaoService.Calcular(vendas);
    }

}