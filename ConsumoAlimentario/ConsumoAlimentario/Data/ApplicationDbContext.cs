using ConsumoAlimentario.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsumoAlimentario.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {

        }
        public DbSet<Alimento> Alimento { get; set; }

    }
}
