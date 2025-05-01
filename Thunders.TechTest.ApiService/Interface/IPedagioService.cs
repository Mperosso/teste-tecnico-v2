using Thunders.TechTest.ApiService.Entities;

namespace Thunders.TechTest.ApiService.Interface
{
    public interface IPedagioService
    {
        Task SavePedagioAsync(Pedagio pedagio);
    }
}
