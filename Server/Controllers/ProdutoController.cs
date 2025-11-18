using Microsoft.AspNetCore.Mvc;
using Shared.Interfaces;

namespace Server.Controllers;

[ApiController]
[Route("api/produtos")]
public class ProdutoController : ControllerBase
{
    private readonly IProdutoService _produtoService;

    public ProdutoController(IProdutoService produtoService)
    {
        _produtoService = produtoService;
    }

    [HttpGet]
    public async Task<IActionResult> GetProdutos()
    {
        var produtos = await _produtoService.ObterProdutos();
        return Ok(produtos);
    }
}