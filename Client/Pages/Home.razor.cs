
using Shared.DTOs;
using Shared.Interfaces;
using Microsoft.AspNetCore.Components;

namespace Client.Pages;

public partial class Home
{
    private string? selecionouProduto;
    private string? selecionouCosif;
    private string? mes;
    private string? ano;
    private string? descricao;
    private decimal valor;
    private bool spinner = false;

    private IEnumerable<ProdutoDto> produtos = new List<ProdutoDto>();
    private IEnumerable<ProdutoCosifDto> produtoCosifs = new List<ProdutoCosifDto>();
    private IEnumerable<MovimentoManualGetDto> MovimentoManualGet = new List<MovimentoManualGetDto>();

    [Inject]
    private IProdutoService ProdutoService { get; set; } = null!;
    [Inject]
    private IProdutoCosifService ProdutoCosif { get; set; } = null!;
    [Inject]
    private IMovimentoManualService MovimentoManual { get; set; } = null!;

    protected override async Task OnInitializedAsync()
    {
        try
        {
            spinner = true;
            await ObterProdutos();
            await ObterCosifs();
            await ObterMovimentosManuais();
        }
        finally
        {
            spinner = false;
            StateHasChanged();
        }
    }

    private void OnSelecionouProduto(ChangeEventArgs e)
    {
        selecionouProduto = e.Value?.ToString();
    }

    private void OnSelecionoucosif(ChangeEventArgs e)
    {
        selecionouCosif = e.Value?.ToString();
    }

    private async Task ObterProdutos()
    {
        try
        {
            produtos = await ProdutoService.ObterProdutos();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"ObterProdutos(): {ex.Message}");
        }
    }

    private async Task ObterCosifs()
    {
        try
        {            
            produtoCosifs = await ProdutoCosif.ObterCosifs();            
        }
        catch (Exception ex)
        {            
            Console.WriteLine($"GetObterCosifs(): {ex.Message}");
        }
    }

    private async Task ObterMovimentosManuais()
    {
        try
        {
            MovimentoManualGet = await MovimentoManual.ObterMovimentosManuais();
            StateHasChanged();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"GetObterMovimentosManuais(): {ex.Message}");
        }
    }

    private void LimparCampos()
    {
        selecionouProduto = null;
        selecionouCosif = null;
        mes = null;
        ano = null;
        valor = 0;
        descricao = null;

        StateHasChanged();
    }

    private async Task AdicionarMovimentoManual()
    {
        try
        {
            spinner = true;
            var dto = new MovimentoManualPostDto
            {
                Mes = int.Parse(mes!),
                Ano = int.Parse(ano!),
                CodigoProduto = selecionouProduto!,
                CodigoCosif = selecionouCosif!,
                DescricaoProduto = descricao!,
                DtMovimento = DateTime.Now,
                CodigoUsuario = "1",
                Valor = valor
            };
            await MovimentoManual.PostMovimentoManual(dto);            
        }
        catch (Exception ex)
        {
            Console.WriteLine($"AdicionarMovimentoManual(): {ex.Message}");
        }
        finally
        {
            await ObterMovimentosManuais();
            LimparCampos();
            spinner = false;
            StateHasChanged();
        }
    }
}