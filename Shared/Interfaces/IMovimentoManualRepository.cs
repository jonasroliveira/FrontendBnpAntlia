using Shared.DTOs;

namespace Shared.Interfaces;

public interface IMovimentoManualRepository
{
    Task<IEnumerable<MovimentoManualGetDto>> ObterMovimentosManuais();

    Task PostMovimentoManual(MovimentoManualPostDto dto);
}