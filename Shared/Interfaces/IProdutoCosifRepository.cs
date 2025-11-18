using Shared.DTOs;

namespace Shared.Interfaces;

public interface IProdutoCosifRepository
{
    Task<IEnumerable<ProdutoCosifDto>> ObterCosifs();
}