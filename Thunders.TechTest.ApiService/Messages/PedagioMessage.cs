using Thunders.TechTest.ApiService.Enum;

namespace Thunders.TechTest.ApiService.Messages
{
    public class PedagioMessage
    {
        public DateTime DataHora { get; set; }
        public int PracaId { get; set; }
        public string Cidade { get; set; }
        public Estados Estado { get; set; }
        public decimal ValorPago { get; set; }
        public TipoVeiculo TipoVeiculo { get; set; }
    }
}
