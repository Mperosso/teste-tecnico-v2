using Thunders.TechTest.ApiService.Enum;

namespace Thunders.TechTest.ApiService.Entities
{
    public class Pedagio
    {
        public DateTime DataHora { get; set; }
        public int PracaId { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public decimal ValorPago { get; set; }
        public TipoVeiculo TipoVeiculo { get; set; }
    }
}
