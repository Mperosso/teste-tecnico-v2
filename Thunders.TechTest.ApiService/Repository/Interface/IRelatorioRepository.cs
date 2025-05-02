using Thunders.TechTest.ApiService.Reports;

namespace Thunders.TechTest.ApiService.Repository.Interface
{
    public interface IRelatorioRepository
    {
        Task SalvarRelatorioFaturamentoPracasAsync(RelatorioFaturamentoPracas relatorio);
        Task SalvarRelatorioVeiculosPracaAsync(RelatorioVeiculosPraca relatorio);
        Task SalvarRelatorioValorHoraCidadeAsync(RelatorioValorHoraCidade relatorio);
    }
}
