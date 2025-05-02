using Microsoft.AspNetCore.Mvc;
using Thunders.TechTest.ApiService.Interface;

namespace Thunders.TechTest.ApiService.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class RelatorioController : ControllerBase
    {
        private readonly IReportService _reportService;
        public RelatorioController(IReportService reportService)
        {
            _reportService = reportService;
        }
        [HttpGet("faturamento-pracas")]
        public async Task<IActionResult> ObterRelatorioPracasMaisFaturaram([FromBody] int numeroPracas)
        {
            if (numeroPracas <= 0)
            {
                return BadRequest("Número de praças inválido.");
            }

            try
            {
                var relatorio = await _reportService.GerarRelatorioFaturamentoPracasAsync(numeroPracas);
                return Ok(relatorio);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("valor-hora-cidade")]
        public async Task<IActionResult> ObterValorHoraCidade([FromBody] DateTime dataInicial, DateTime dataFinal)
        {
            if (dataInicial == default || dataFinal == default)
            {
                return BadRequest("Data inicial ou final inválida.");
            }

            try
            {
                var relatorio = await _reportService.GerarRelatorioValorHoraCidadeAsync(dataInicial, dataFinal);
                return Ok(relatorio);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("veiculos-praca")]
        public async Task<IActionResult> ObterVeiculosPraca([FromBody] int pracaId)
        {
            if (pracaId <= 0)
            {
                return BadRequest("ID da praça inválido.");
            }

            try
            {
                var relatorio = await _reportService.GerarRelatorioVeiculosPracaAsync(pracaId);
                return Ok(relatorio);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }   
            
        }
    }
}
