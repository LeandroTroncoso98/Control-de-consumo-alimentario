using ConsumoAlimentario.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsumoAlimentario.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        public DbSet<Alimento> Alimento { get; set; }
        public DbSet<ConsumoDiario> ConsumoDiario { get; set; }
        public DbSet<AlimentoCargado> AlimentoCargado { get; set; }

    }
}
