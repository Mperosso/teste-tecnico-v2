using Thunders.TechTest.ApiService.Enum;
using Thunders.TechTest.ApiService.Interface;
using Thunders.TechTest.ApiService.Reports;
using Thunders.TechTest.ApiService.Repository.Interface;

namespace Thunders.TechTest.ApiService.Services
{
    public class ReportService : IReportService
    {
        private readonly IPedagioRepository _pedagioRepository;
        private readonly IRelatorioRepository _relatorioRepository;

        public ReportService(IPedagioRepository pedagioRepository, IRelatorioRepository relatorioRepository)
        {
            _pedagioRepository = pedagioRepository;
            _relatorioRepository = relatorioRepository;
        }

        public async Task<List<RelatorioFaturamentoPracas>> GerarRelatorioFaturamentoPracasAsync(int numeroPracas)
        {
            var pedagios = await _pedagioRepository.ObterPedagiosAsync();

            var relatorio = pedagios
                .GroupBy(p => new { p.PracaId, p.Cidade, p.Estado, p.DataHora.Month, p.DataHora.Year})
                .Select(g => new RelatorioFaturamentoPracas
                {
                    PracaId = g.Key.PracaId,
                    Cidade = g.Key.Cidade,
                    Estado = g.Key.Estado,
                    Mes = g.Key.Month,
                    Ano = g.Key.Year,
                    ValorTotal = g.Sum(p => p.ValorPago)
                })
                .OrderByDescending(r => r.ValorTotal)
                .Take(numeroPracas)
                .ToList();

            foreach (var item in relatorio)
            {
                await _relatorioRepository.SalvarRelatorioFaturamentoPracasAsync(item);
            }

            return relatorio;
        }

        public async Task<List<RelatorioValorHoraCidade>> GerarRelatorioValorHoraCidadeAsync(DateTime dataInicial, DateTime dataFinal)
        {
            var pedagios = await _pedagioRepository.ObterPedagiosAsync();

            var relatorio = pedagios
                .GroupBy(p => new { p.DataHora.Date, p.DataHora.Hour, p.Cidade, p.Estado})
                .Where(g => new DateTime(g.Key.Date.Year, g.Key.Date.Month, g.Key.Date.Day, g.Key.Hour, 0, 0) >= dataInicial 
                && new DateTime(g.Key.Date.Year, g.Key.Date.Month, g.Key.Date.Day, g.Key.Hour, 0, 0) <= dataFinal)
                .Select(g => new RelatorioValorHoraCidade
                {
                    Hora = new DateTime(g.Key.Date.Year, g.Key.Date.Month, g.Key.Date.Day, g.Key.Hour, 0, 0),
                    Cidade = g.Key.Cidade,
                    Estado = g.Key.Estado,
                    ValorTotal = g.Sum(p => p.ValorPago)
                })
                .OrderByDescending(r => r.ValorTotal)
                .ToList();

            foreach (var item in relatorio)
            {
                await _relatorioRepository.SalvarRelatorioValorHoraCidadeAsync(item);
            }

            return relatorio;
        }

        public Task<RelatorioVeiculosPraca> GerarRelatorioVeiculosPracaAsync(int pracaId)
        {
            var pedagios = _pedagioRepository.ObterPedagiosPorPracaIdAsync(pracaId);

            RelatorioVeiculosPraca relatorio = new RelatorioVeiculosPraca();
            relatorio.PracaId = pracaId;

            relatorio.QuantidadeMotos = pedagios.Result.Count(p => p.TipoVeiculo == TipoVeiculo.Moto);
            relatorio.QuantidadeCarros = pedagios.Result.Count(p => p.TipoVeiculo == TipoVeiculo.Carro);
            relatorio.QuantidadeCaminhoes = pedagios.Result.Count(p => p.TipoVeiculo == TipoVeiculo.Caminhao);


            return Task.FromResult(relatorio);
        }
    }
}
