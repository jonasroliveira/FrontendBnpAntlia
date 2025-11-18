using Shared.DTOs;
using Shared.Interfaces;

namespace Server.Repositories;

public class ProdutoCosifRepository : IProdutoCosifRepository
{
    private readonly HttpClient _httpClient;

    public ProdutoCosifRepository(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress ??= new Uri("http://localhost:5036/api/produtos-cosif");
    }

    public async Task<IEnumerable<ProdutoCosifDto>> ObterCosifs()
    {
        var response = await _httpClient.GetAsync("");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<IEnumerable<ProdutoCosifDto>>() ?? Enumerable.Empty<ProdutoCosifDto>();
    }
}