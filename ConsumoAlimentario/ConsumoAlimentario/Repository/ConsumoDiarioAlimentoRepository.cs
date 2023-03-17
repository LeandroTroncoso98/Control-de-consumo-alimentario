using ConsumoAlimentario.Data;
using ConsumoAlimentario.Models;
using ConsumoAlimentario.Repository.IRepository;

namespace ConsumoAlimentario.Repository
{
    public class ConsumoDiarioAlimentoRepository : IConsumoDiarioAlimentoRepository
    {
        private readonly ApplicationDbContext _context;
        public ConsumoDiarioAlimentoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool AgregarAlimentoAConsumo(ConsumoDiarioAlimento consumoDiarioAlimento)
        {
            _context.ConsumoDiarioAlimento.Add(consumoDiarioAlimento);
            return Guardar();
        }
        public bool QuitarAlimentoAConsumo(ConsumoDiarioAlimento consumoDiarioAlimento)
        {
            _context.ConsumoDiarioAlimento.Remove(consumoDiarioAlimento);
            return Guardar();
        }
        public bool Guardar()
        {
            return _context.SaveChanges() >= 0 ? true : false;
        }
    }
}
