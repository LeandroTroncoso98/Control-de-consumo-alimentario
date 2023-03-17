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
            builder.Entity<ConsumoDiarioAlimento>().HasKey(c => new {c.ConsumoDiario_Id,c.Alimento_Id});
            base.OnModelCreating(builder);
        }
        public DbSet<Alimento> Alimento { get; set; }
        public DbSet<ConsumoDiario> ConsumoDiario { get; set; }
        public DbSet<ConsumoDiarioAlimento> ConsumoDiarioAlimento { get; set; }
        public DbSet<AlimentoCargado> AlimentoCargado { get; set; }

    }
}
