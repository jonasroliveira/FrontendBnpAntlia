
using System.Net.Http.Json;
using Shared.DTOs;
using Shared.Interfaces;

namespace Client.Services;

public class MovimentoManualService : IMovimentoManualService
{

    private readonly HttpClient _httpClient;

    public MovimentoManualService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<MovimentoManualGetDto>> ObterMovimentosManuais()
    {
        var response = await _httpClient.GetAsync("api/movimentos-manuais");
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<IEnumerable<MovimentoManualGetDto>>() ?? new List<MovimentoManualGetDto>();
        }
        return Enumerable.Empty<MovimentoManualGetDto>();

    }
    public async Task PostMovimentoManual(MovimentoManualPostDto dto)
    {
        var response = await _httpClient.PostAsJsonAsync("api/movimentos-manuais", dto);
        if (response.IsSuccessStatusCode)
        {
            await response.Content.ReadFromJsonAsync<MovimentoManualGetDto>();
        }
    }
}