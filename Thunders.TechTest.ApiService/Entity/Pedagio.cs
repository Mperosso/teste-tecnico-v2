﻿using System.ComponentModel.DataAnnotations.Schema;
using Thunders.TechTest.ApiService.Enum;

namespace Thunders.TechTest.ApiService.Entities
{
    [Table("PEDAGIOS")]
    public class Pedagio
    {
        public int Id { get; internal set; }
        public DateTime DataHora { get; set; }
        public int PracaId { get; set; }
        public string Cidade { get; set; }
        public Estados Estado { get; set; }
        public decimal ValorPago { get; set; }
        public TipoVeiculo TipoVeiculo { get; set; }
    }
}
