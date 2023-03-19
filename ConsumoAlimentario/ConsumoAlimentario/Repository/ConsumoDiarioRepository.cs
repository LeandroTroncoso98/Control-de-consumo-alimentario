using ConsumoAlimentario.Data;
using ConsumoAlimentario.Models;
using ConsumoAlimentario.Repository.IRepository;
using System.ComponentModel;

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
        public bool AgregarAlimentoAConsumo(int consumoDiarioId,AlimentoCargado alimentoCargado)
        {
            var consumoDiario = _context.ConsumoDiario.FirstOrDefault(c => c.ConsumoDiario_Id== consumoDiarioId);
            consumoDiario.AlimentoCargados.Add(alimentoCargado);
            SumarNutrientres();
            return Guardar();
        }
        public void SumarNutrientres()
        {

        }
    }
}
