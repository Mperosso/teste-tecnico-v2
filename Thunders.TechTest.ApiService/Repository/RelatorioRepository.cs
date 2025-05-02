using Thunders.TechTest.ApiService.Reports;
using Thunders.TechTest.ApiService.Repository.Context;
using Thunders.TechTest.ApiService.Repository.Interface;

namespace Thunders.TechTest.ApiService.Repository
{
    public class RelatorioRepository : IRelatorioRepository
    {
        private readonly PedagioDbContext _context;

        public RelatorioRepository(PedagioDbContext context)
        {
            _context = context;
        }

        public async Task SalvarRelatorioFaturamentoPracasAsync(RelatorioFaturamentoPracas relatorio)
        {
            await _context.RelatorioFaturamentoPracas.AddAsync(relatorio);
            await _context.SaveChangesAsync();
        }

        public async Task SalvarRelatorioValorHoraCidadeAsync(RelatorioValorHoraCidade relatorio)
        {
            await _context.RelatorioValorHoraCidade.AddAsync(relatorio);
            await _context.SaveChangesAsync();
        }

        public async Task SalvarRelatorioVeiculosPracaAsync(RelatorioVeiculosPraca relatorio)
        {
            await _context.RelatorioVeiculosPraca.AddAsync(relatorio);
            await _context.SaveChangesAsync();
        }
    }
}
