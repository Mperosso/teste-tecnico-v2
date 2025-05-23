﻿using Thunders.TechTest.ApiService.Entities;

namespace Thunders.TechTest.ApiService.Repository.Interface
{
    public interface IPedagioRepository
    {
        Task SalvarPedagioAsync(Pedagio pedagio);
        Task<List<Pedagio>> ObterPedagiosAsync();
        Task<List<Pedagio>> ObterPedagiosPorPracaIdAsync(int pracaId);
    }
}
