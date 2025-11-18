using Shared.DTOs;

namespace Shared.Interfaces;

public interface IMovimentoManualService
{
    Task<IEnumerable<MovimentoManualGetDto>> ObterMovimentosManuais();
    Task PostMovimentoManual(MovimentoManualPostDto dto);
}