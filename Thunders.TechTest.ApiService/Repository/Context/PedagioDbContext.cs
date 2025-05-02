using Microsoft.EntityFrameworkCore;
using Thunders.TechTest.ApiService.Entities;
using Thunders.TechTest.ApiService.Reports;

namespace Thunders.TechTest.ApiService.Repository.Context
{
    public class PedagioDbContext : DbContext
    {
        public DbSet<Pedagio> Pedagios { get; set; }
        public DbSet<RelatorioFaturamentoPracas> RelatorioFaturamentoPracas { get; set; }
        public DbSet<RelatorioVeiculosPraca> RelatorioVeiculosPraca { get; set; }
        public DbSet<RelatorioValorHoraCidade> RelatorioValorHoraCidade { get; set; }

        public PedagioDbContext(DbContextOptions<PedagioDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pedagio>(pedagio =>
            {
                pedagio.ToTable("PEDAGIOS");
                pedagio.HasKey(p => p.Id);
                pedagio.Property(p => p.Id).ValueGeneratedOnAdd();
                pedagio.Property(p => p.DataHora).IsRequired();
                pedagio.Property(p => p.PracaId).IsRequired();
                pedagio.Property(p => p.Cidade).IsRequired().HasMaxLength(100);
                pedagio.Property(p => p.Estado).IsRequired();
                pedagio.Property(p => p.ValorPago).IsRequired().HasColumnType("decimal(18,2)");
                pedagio.Property(p => p.TipoVeiculo).IsRequired();
            });
        }
    }
}
