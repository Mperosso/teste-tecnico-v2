using Thunders.TechTest.ApiService.Messages;
using Thunders.TechTest.OutOfBox.Queues;

namespace Thunders.TechTest.ApiService.Services
{
    public class MessageService
    {
        private readonly RebusMessageSender _messageSender;
        public MessageService(RebusMessageSender messageSender)
        {
            _messageSender = messageSender;
        }

        public async Task EnviarMensagemSalvarUtilizacao(PedagioMessage mensagem)
        {
            await _messageSender.SendLocal(mensagem);
        }

    }
}
