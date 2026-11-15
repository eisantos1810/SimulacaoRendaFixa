using SimulacaoRendaFixa.Models;
using SimulacaoRendaFixa.Services;

﻿namespace SimulacaoRendaFixa.Tests;

public class CalculadoraServiceTests
{
    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void Simular_DeveRejeitarValorAplicadoMenorOuIgualAZero(decimal valorAplicado)
    {
        var service = new CalculadoraService();
        var request = new SimulacaoRequest(
            ValorAplicado: valorAplicado,
            PrazoDias: 90,
            TaxaAnual: 0.12m
        );

        var exception = Assert.Throws<ArgumentException>(() => service.Simular(request));

        Assert.Equal("Valor aplicado deve ser maior que zero", exception.Message);
    }

    [Fact]
    public void Simular_DeveCalcularRendimentoComIRParaPrazoDe90Dias()
    {
        // Arrange
        var service = new CalculadoraService();
        var request = new SimulacaoRequest(
            ValorAplicado: 10000m,
            PrazoDias: 90,
            TaxaAnual: 0.12m
        );

        // Act
        var resultado = service.Simular(request);

        // Assert
        Assert.Equal(10000m, resultado.ValorAplicado);
        Assert.Equal(295.89m, resultado.RendimentoBruto);
        Assert.Equal(0.225m, resultado.AliquotaIR);
        Assert.Equal(66.58m, resultado.ValorIR);
        Assert.Equal(10229.32m, resultado.ValorLiquido);
    }

    [Fact]
    public void Simular_DeveCalcularRendimentoComIRParaPrazoDe180Dias()
    {
        // Arrange
        var service = new CalculadoraService();
        var request = new SimulacaoRequest(
            ValorAplicado: 5000m,
            PrazoDias: 180,
            TaxaAnual: 0.10m
        );

        // Act
        var resultado = service.Simular(request);

        // Assert
        Assert.Equal(5000m, resultado.ValorAplicado);
        Assert.Equal(246.58m, resultado.RendimentoBruto);
        Assert.Equal(0.225m, resultado.AliquotaIR);
        Assert.Equal(55.48m, resultado.ValorIR);
        Assert.Equal(5191.10m, resultado.ValorLiquido);
    }
}
