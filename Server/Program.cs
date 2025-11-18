//Jonas da Rosa Oliveira
//18/11/2025
//https://www.linkedin.com/in/jonas-da-rosa-oliveira

using Server.Repositories;
using Server.Services;
using Shared.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient();

builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
builder.Services.AddScoped<IProdutoCosifRepository, ProdutoCosifRepository>();
builder.Services.AddScoped<IMovimentoManualRepository, MovimentoManualRepository>();

builder.Services.AddScoped<IProdutoService, ProdutoService>();
builder.Services.AddScoped<IProdutoCosifService, ProdutoCosifService>();
builder.Services.AddScoped<IMovimentoManualService, MovimentoManualService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseBlazorFrameworkFiles();
app.UseStaticFiles();
app.MapControllers();
app.MapFallbackToFile("index.html");
app.Run();
