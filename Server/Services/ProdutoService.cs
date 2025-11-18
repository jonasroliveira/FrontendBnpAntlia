using Shared.DTOs;
using Shared.Interfaces;
using System.Text.Json;

namespace Server.Services;

public class ProdutoService : IProdutoService
{
    private readonly IProdutoRepository _produtoRepository;

    public ProdutoService(IProdutoRepository produtoRepository)
    {
        _produtoRepository = produtoRepository;
    }

    public Task<IEnumerable<ProdutoDto>> ObterProdutos() => _produtoRepository.ObterProdutos();
}