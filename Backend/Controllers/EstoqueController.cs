using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]

public class EstoqueController : ControllerBase
{
    private readonly EstoqueService _estoqueService;

    public EstoqueController(EstoqueService estoqueService)
    {
        _estoqueService = estoqueService;
    }
    [HttpPost]
    public IActionResult MovimentarEstoque(MovimentacaoEstoque movimentacao)
    {
        try
        {
            var produtos = _estoqueService.CarregarEstoque();
            var produto = _estoqueService.BuscarProduto(produtos, movimentacao.CodigoProduto);
            var estoqueAtualizado =
            _estoqueService.MovimentacaoDeEstoque(
                movimentacao,
                produto
            );

            _estoqueService.SalvarEstoque(produtos);

            return Ok(estoqueAtualizado);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

}