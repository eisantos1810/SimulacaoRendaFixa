namespace SimulacaoRendaFixa.Models;

public record SimulacaoRequest(
    decimal ValorAplicado,
    int PrazoDias,
    decimal TaxaAnual
);