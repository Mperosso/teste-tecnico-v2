using Microsoft.EntityFrameworkCore;
using System.Net.Sockets;
using Thunders.TechTest.ApiService.Entities;
using Thunders.TechTest.ApiService.Repository.Context;
using Thunders.TechTest.ApiService.Repository.Interface;

namespace Thunders.TechTest.ApiService.Repository
{
    public class PedagioRepository : IPedagioRepository
    {
        private readonly PedagioDbContext _pedagioContext;

        public PedagioRepository(PedagioDbContext pedagioContext)
        {
            _pedagioContext = pedagioContext;
        }

        public async Task<List<Pedagio>> ObterPedagiosAsync()
        {
            return await _pedagioContext.Pedagios.ToListAsync();
        }

        public Task<List<Pedagio>> ObterPedagiosPorPracaIdAsync(int pracaId)
        {
            return _pedagioContext.Pedagios.Where(p => p.PracaId == pracaId).ToListAsync();
        }

        public async Task SalvarPedagioAsync(Pedagio pedagio)
        {
            await _pedagioContext.Pedagios.AddAsync(pedagio);
            await _pedagioContext.SaveChangesAsync();
        }
    }
}
