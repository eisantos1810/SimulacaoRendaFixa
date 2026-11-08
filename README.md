markdown# SimulacaoRendaFixa 💰

API em C# (.NET) para simular investimento em Renda Fixa, com cálculo de IR regressivo e validações de negócio.

## Como rodar

```bash
dotnet runA API vai subir em http://localhost:5261
Endpoint
POST /simular
Request:
json
{
  "valorAplicado": 10000,
  "prazoDias": 90,
  "taxaAnual": 0.12
}Response 200 - Sucesso:
json
{
  "valorAplicado": 10000,
  "rendimentoBruto": 295.89,
  "aliquotaIR": 0.225,
  "valorIR": 66.58,
  "valorLiquido": 10229.32
}Response 400 - Erro de validação:
json
{
  "erro": "Taxa anual não pode ser negativa"
}Regra de Negócio - Tabela Regressiva do IR
PrazoAlíquota
Até 180 dias22,5%
181 a 360 dias20%
361 a 720 dias17,5%
Acima de 720 dias15%
Validações
Valor aplicado deve ser maior que zeroPrazo em dias deve ser maior que zeroTaxa anual não pode ser negativa
Tecnologias
C# / .NET
Minimal APIComo testar
Com curl:
bash
curl -X POST http://localhost:5261/simular -H "Content-Type: application/json" -d '{"valorAplicado":10000,"prazoDias":90,"taxaAnual":0.12}'
Ou importando no Bruno / Postman.javascript
