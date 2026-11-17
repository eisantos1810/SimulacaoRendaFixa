using SimulacaoRendaFixa.Models;

namespace SimulacaoRendaFixa.Services;

public class CalculadoraService : ICalculadoraService
{
    public SimulacaoResponse Simular(SimulacaoRequest request)
    {
        if (request.ValorAplicado <= 0)
            throw new ArgumentException("Valor aplicado deve ser maior que zero");
        if (request.PrazoDias <= 0)
            throw new ArgumentException("Prazo deve ser maior que zero");
        if (request.TaxaAnual < 0)
            throw new ArgumentException("Taxa anual não pode ser negativa");

        decimal rendimentoBruto = request.ValorAplicado * request.TaxaAnual * request.PrazoDias / 365;

        decimal aliquota = request.PrazoDias switch
        {
            <= 180 => 0.225m,
            <= 360 => 0.20m,
            <= 720 => 0.175m,
            _ => 0.15m
        };

        decimal valorIR = rendimentoBruto * aliquota;
        decimal valorLiquido = request.ValorAplicado + rendimentoBruto - valorIR;

        return new SimulacaoResponse(
            request.ValorAplicado,
            Math.Round(rendimentoBruto, 2),
            aliquota,
            Math.Round(valorIR, 2),
            Math.Round(valorLiquido, 2)
        );
    }
}