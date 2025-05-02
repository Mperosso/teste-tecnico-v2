using Thunders.TechTest.ApiService.Enum;

namespace Thunders.TechTest.ApiService.Reports
{
    public class RelatorioFaturamentoPracas
    {
        public int Id { get; set; }
        public int PracaId { get; set; }
        public string Cidade { get; set; }
        public Estados Estado { get; set; }
        public int Mes { get; set; }
        public int Ano { get; set; }
        public decimal ValorTotal { get; set; }

    }
}
