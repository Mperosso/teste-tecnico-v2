using Rebus.Handlers;
using Rebus.Messages;
using Thunders.TechTest.ApiService.Entities;
using Thunders.TechTest.ApiService.Interface;
using Thunders.TechTest.ApiService.Messages;

namespace Thunders.TechTest.ApiService.Handler
{
    public class PedagioMessageHandler : IHandleMessages<PedagioMessage>
    {
        private readonly IPedagioService _service;

        public PedagioMessageHandler(IPedagioService service) 
        {
            _service = service;
        }

        public async Task Handle(PedagioMessage message)
        {
            var pedagio = new Pedagio
            {
                DataHora = message.DataHora,
                PracaId = message.PracaId,
                Cidade = message.Cidade,
                Estado = message.Estado,
                ValorPago = message.ValorPago,
                TipoVeiculo = message.TipoVeiculo
            };

            await _service.SavePedagioAsync(pedagio);
        }
    }
}
