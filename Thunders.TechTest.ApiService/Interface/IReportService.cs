using Thunders.TechTest.ApiService.Reports;

namespace Thunders.TechTest.ApiService.Interface
{
    public interface IReportService
    {
        Task<List<RelatorioValorHoraCidade>> GerarRelatorioValorHoraCidadeAsync(DateTime dataInicial, DateTime dataFinal);
        Task<List<RelatorioFaturamentoPracas>> GerarRelatorioFaturamentoPracasAsync(int numeroPracas);
        Task<RelatorioVeiculosPraca> GerarRelatorioVeiculosPracaAsync(int pracaId);

    }
}

