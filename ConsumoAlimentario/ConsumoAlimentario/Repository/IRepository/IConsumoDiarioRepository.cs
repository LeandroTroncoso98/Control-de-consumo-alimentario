using ConsumoAlimentario.Models;

namespace ConsumoAlimentario.Repository.IRepository
{
    public interface IConsumoDiarioRepository
    {
        ICollection<ConsumoDiario> GetAll();
        ConsumoDiario Get(int id);
        bool Guardar();
        bool CrearConsumoDiario(ConsumoDiario consumo);
    }
}
