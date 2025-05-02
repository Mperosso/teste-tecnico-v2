using Thunders.TechTest.ApiService.Enum;

namespace Thunders.TechTest.ApiService.Reports
{
    public class RelatorioVeiculosPraca
    {
        public int Id { get; set; }
        public int PracaId { get; set; }
        public int QuantidadeMotos { get; set; }
        public int QuantidadeCarros { get; set; }
        public int QuantidadeCaminhoes { get; set; }

    }
}
