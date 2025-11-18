using Shared.DTOs;
using Shared.Interfaces;

namespace Server.Repositories;

public class MovimentoManualRepository : IMovimentoManualRepository
{

    private readonly HttpClient _httpClient;

    public MovimentoManualRepository(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress ??= new Uri("http://localhost:5036/api/movimentos-manuais");
    }

    public async Task<IEnumerable<MovimentoManualGetDto>> ObterMovimentosManuais()
    {
        var response = await _httpClient.GetAsync("");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<IEnumerable<MovimentoManualGetDto>>() ?? Enumerable.Empty<MovimentoManualGetDto>();
    }

    public async Task PostMovimentoManual(MovimentoManualPostDto dto)
    {
        var response = await _httpClient.PostAsJsonAsync("", dto);
        response.EnsureSuccessStatusCode();        
    }
}