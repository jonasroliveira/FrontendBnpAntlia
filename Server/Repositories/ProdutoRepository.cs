using Shared.DTOs;
using Shared.Interfaces;

namespace Server.Repositories;

public class ProdutoRepository : IProdutoRepository
{
    private readonly HttpClient _httpClient;

    public ProdutoRepository(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress ??= new Uri("http://localhost:5036/api/produtos");
    }

    public async Task<IEnumerable<ProdutoDto>> ObterProdutos()
    {
        var response = await _httpClient.GetAsync("");
        response.EnsureSuccessStatusCode();
        var produtos = await response.Content.ReadFromJsonAsync<IEnumerable<ProdutoDto>>();
        return produtos ?? Enumerable.Empty<ProdutoDto>();
    }
}