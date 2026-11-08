using SimulacaoRendaFixa.Models;

namespace SimulacaoRendaFixa.Services;

public interface ICalculadoraService
{
    SimulacaoResponse Simular(SimulacaoRequest request);
}