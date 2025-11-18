using Shared.DTOs;

namespace Shared.Interfaces;

public interface IProdutoCosifService
{
    Task<IEnumerable<ProdutoCosifDto>> ObterCosifs();
}