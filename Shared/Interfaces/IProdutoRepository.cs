using Shared.DTOs;

namespace Shared.Interfaces;

public interface IProdutoRepository
{
    Task<IEnumerable<ProdutoDto>> ObterProdutos();
}