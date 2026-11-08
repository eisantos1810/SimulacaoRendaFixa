namespace SimulacaoRendaFixa.Models;

public record SimulacaoResponse(
    decimal ValorAplicado,
    decimal RendimentoBruto,
    decimal AliquotaIR,
    decimal ValorIR,
    decimal ValorLiquido
);