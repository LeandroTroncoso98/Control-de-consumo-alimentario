using ConsumoAlimentario.Models;

namespace ConsumoAlimentario.Repository.IRepository
{
    public interface IAlimentoRepository
    {
        ICollection<Alimento> GetAlimentos();
        Alimento GetAlimento(int alimentoId);
        bool ExisteAlimento(string nombreAlimento);
        bool ExisteAlimento(int id);
        bool CrearAliemento(Alimento alimento);
        bool EditarAlimento(Alimento alimento);
        bool BorrarAlimento(Alimento alimento);
        bool Guardar();
    }
}
