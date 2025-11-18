using Shared.DTOs;

namespace Shared.Interfaces;

public interface IProdutoService
{
    Task<IEnumerable<ProdutoDto>> ObterProdutos();
}