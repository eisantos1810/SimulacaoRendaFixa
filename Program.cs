using SimulacaoRendaFixa.Models;
using SimulacaoRendaFixa.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ICalculadoraService, CalculadoraService>();

var app = builder.Build();

app.MapPost("/simular", (SimulacaoRequest request, ICalculadoraService service) =>
{
    try
    {
        var resultado = service.Simular(request);
        return Results.Ok(resultado);
    }
    catch (ArgumentException ex)
    {
        return Results.BadRequest(new { erro = ex.Message });
    }
});

app.Run();