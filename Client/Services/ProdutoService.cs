using System.Net.Http.Json;
using Shared.DTOs;
using Shared.Interfaces;

namespace Client.Services;

public class ProdutoService : IProdutoService
{

    private readonly HttpClient _httpClient;

    public ProdutoService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<ProdutoDto>> ObterProdutos()
    {
        var response = await _httpClient.GetAsync("api/produtos");
         if (response.IsSuccessStatusCode)
         {
             return await response.Content.ReadFromJsonAsync<IEnumerable<ProdutoDto>>() ?? new List<ProdutoDto>();
         }
            return Enumerable.Empty<ProdutoDto>();
    }
}