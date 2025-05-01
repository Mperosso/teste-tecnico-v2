using Microsoft.EntityFrameworkCore;

namespace Thunders.TechTest.ApiService.Repository.Context
{
    public class PedagioDbContext : DbContext
    {
        public DbSet<Entities.Pedagio> Pedagios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entities.Pedagio>().ToTable("Pedagios");
            modelBuilder.Entity<Entities.Pedagio>().HasKey(p => p.Id);
            modelBuilder.Entity<Entities.Pedagio>().Property(p => p.Id).ValueGeneratedOnAdd();
        }
    }
}
