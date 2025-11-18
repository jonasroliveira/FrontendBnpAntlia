using System.Net.Http.Json;
using Shared.DTOs;
using Shared.Interfaces;

namespace Client.Services;
public class ProdutoCosifService : IProdutoCosifService
{

    private readonly HttpClient _httpClient;

    public ProdutoCosifService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<ProdutoCosifDto>> ObterCosifs()
    {
        var response = await _httpClient.GetAsync("api/produtos-cosif");
         if (response.IsSuccessStatusCode)
         {
             return await response.Content.ReadFromJsonAsync<IEnumerable<ProdutoCosifDto>>() ?? new List<ProdutoCosifDto>();
         }
            return Enumerable.Empty<ProdutoCosifDto>();
        
    }
}