using Thunders.TechTest.ApiService.Enum;

namespace Thunders.TechTest.ApiService.Reports
{
    public class RelatorioValorHoraCidade
    {
        public DateTime Hora { get; set; }
        public string Cidade { get; set; }
        public Estados Estado { get; set; }    
        public decimal ValorTotal { get; set; }
    }
}
