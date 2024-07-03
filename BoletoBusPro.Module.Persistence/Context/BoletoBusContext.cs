using BoletoBusPro.Module.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BoletoBusPro.Module.Persistence.Context
{
    public class BoletoBusContext : DbContext
    {
        public BoletoBusContext(DbContextOptions<BoletoBusContext> options) : base(options)
        {
        }

        public DbSet<Bus> Buses { get; set; }
        public DbSet<Asiento> Asientos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Bus>().ToTable("Bus");
            modelBuilder.Entity<Asiento>().ToTable("Asiento");
        }
    }
}

