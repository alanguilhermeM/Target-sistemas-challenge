using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]

public class JurosController : ControllerBase
{
    private readonly JurosService _jurosService;

    public JurosController(JurosService jurosService)
    {
        _jurosService = jurosService;
    }
    [HttpPost]
    public CalculoJurosResponse Calcular(CalculoJurosRequest request)
    {
        return _jurosService.CalcularJuros(request);
    }

}