
using Shared.DTOs;
using Shared.Interfaces;

namespace Server.Services;

public class MovimentoManualService : IMovimentoManualService
{
    private readonly IMovimentoManualRepository _movimentoManualRepository;

    public MovimentoManualService(IMovimentoManualRepository movimentoManualRepository)
    {
        _movimentoManualRepository = movimentoManualRepository;
    }

    public Task<IEnumerable<MovimentoManualGetDto>> ObterMovimentosManuais() => _movimentoManualRepository.ObterMovimentosManuais();

    public Task PostMovimentoManual(MovimentoManualPostDto dto) => _movimentoManualRepository.PostMovimentoManual(dto);
}