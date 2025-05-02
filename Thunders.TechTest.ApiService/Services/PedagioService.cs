using Thunders.TechTest.ApiService.Entities;
using Thunders.TechTest.ApiService.Interface;
using Thunders.TechTest.ApiService.Repository.Interface;

namespace Thunders.TechTest.ApiService.Services
{
    public class PedagioService : IPedagioService
    {
        private readonly IPedagioRepository _pedagioRepository;
        public PedagioService(IPedagioRepository pedagioRepository)
        {
            _pedagioRepository = pedagioRepository;
        }
        public async Task SavePedagioAsync(Pedagio pedagio)
        {
            if (pedagio == null)
                throw new ArgumentNullException(nameof(pedagio));
            try
            {
                await _pedagioRepository.SalvarPedagioAsync(pedagio);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao salvar pedagio", ex);
            }
        }
    }
}
