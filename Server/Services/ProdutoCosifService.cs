using Shared.DTOs;
using Shared.Interfaces;

namespace Server.Services;

public class ProdutoCosifService : IProdutoCosifService
{
    private readonly IProdutoCosifRepository _produtoCosifRepository;

    public ProdutoCosifService(IProdutoCosifRepository produtoCosifRepository)
    {
        _produtoCosifRepository = produtoCosifRepository;
    }

    public Task<IEnumerable<ProdutoCosifDto>> ObterCosifs() => _produtoCosifRepository.ObterCosifs();
}