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
        public async Task<IActionResult> ObterRelatorioPracasMaisFaturaram(int numeroPracas)
        {
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
        public async Task<IActionResult> ObterValorHoraCidade(DateTime dataInicial, DateTime dataFinal)
        {
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
        public async Task<IActionResult> ObterVeiculosPraca(int pracaId)
        {
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
