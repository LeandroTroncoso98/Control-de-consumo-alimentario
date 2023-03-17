using ConsumoAlimentario.Data;
using ConsumoAlimentario.Models;
using ConsumoAlimentario.Repository.IRepository;

namespace ConsumoAlimentario.Repository
{
    public class ConsumoDiarioRepository : IConsumoDiarioRepository
    {
        private readonly ApplicationDbContext _context;
        public ConsumoDiarioRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool CrearConsumoDiario(ConsumoDiario consumo)
        {
            _context.ConsumoDiario.Add(consumo);
            return Guardar();
        }
        public ConsumoDiario Get(int id)
        {
            return _context.ConsumoDiario.FirstOrDefault(c => c.ConsumoDiario_Id== id);
        }
        public ConsumoDiario Get(DateTime Fecha)
        {
            return _context.ConsumoDiario.FirstOrDefault(c => c.Fecha== Fecha);
        }

        public bool Existe(DateTime fecha)
        {
            return _context.ConsumoDiario.Any(c => c.Fecha== fecha);
        }

        public ICollection<ConsumoDiario> GetAll()
        {
            return _context.ConsumoDiario.OrderBy(c => c.Fecha).ToList();
        }

        public bool Guardar()
        {
            return _context.SaveChanges() >= 0 ? true : false;
        }
    }
}
