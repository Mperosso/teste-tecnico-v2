using Microsoft.AspNetCore.Mvc;
using Thunders.TechTest.ApiService.Messages;
using Thunders.TechTest.ApiService.Services;

namespace Thunders.TechTest.ApiService.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedagioController : ControllerBase
    {
        private readonly MessageService _messageService;
        public PedagioController(MessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpPost]
        public async Task<IActionResult> Salvar([FromBody] PedagioMessage pedagioMessage)
        {
            if (pedagioMessage == null)
            {
                return BadRequest("Requisição inválida.");
            }

            try
            {
                await _messageService.EnviarMensagemSalvarUtilizacao(pedagioMessage);
                return Ok("Requisição enviada com sucesso.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao enviar requisição: {ex.Message}");
            }
        }
    }
}
