using Thunders.TechTest.ApiService.Reports;

namespace Thunders.TechTest.ApiService.Interface
{
    public interface IReportService
    {
        Task<RelatorioValorHoraCidade> GerarRelatorioValorHoraCidadeAsync();
        Task<RelatorioFaturamentoPracas> GerarRelatorioFaturamentoPracasAsync(int numeroPracas);
        Task<RelatorioVeiculosPraca> GerarRelatorioVeiculosPracaAsync(int pracaId);

    }
}
