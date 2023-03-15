using ConsumoAlimentario.Data;
using ConsumoAlimentario.Models;
using ConsumoAlimentario.Repository.IRepository;
using System.Text.RegularExpressions;

namespace ConsumoAlimentario.Repository
{
    public class AlimentoRepository : IAlimentoRepository
    {
        private readonly ApplicationDbContext _context;
        public AlimentoRepository(ApplicationDbContext db)
        {
            _context= db;
        }
        public bool BorrarAlimento(Alimento alimento)
        {
            _context.Alimento.Remove(alimento);
            return Guardar();
        }

        public bool CrearAliemento(Alimento alimento)
        {
            _context.Alimento.Add(alimento);
            return Guardar();
        }

        public bool EditarAlimento(Alimento alimento)
        {
            _context.Alimento.Remove(alimento);
            return Guardar();
        }

        public bool ExisteAlimento(string nombreAlimento)
        {
            bool valor = _context.Alimento.Any(c => c.Nombre.ToLower().Trim() == nombreAlimento.ToLower().Trim());
            return valor;
        }

        public bool ExisteAlimento(int id)
        {
            bool valor = _context.Alimento.Any(c => c.Alimento_Id == id);
            return valor;
        }

        public Alimento GetAlimento(int alimentoId)
        {
            var alimento = _context.Alimento.FirstOrDefault(a => a.Alimento_Id == alimentoId);
            return alimento;
        }

        public ICollection<Alimento> GetAlimentos()
        {
            return _context.Alimento.OrderBy(c => c.Nombre).ToList();
        }

        public bool Guardar()
        {
            return _context.SaveChanges() >= 0 ? true : false;
        }
    }
}
