using ConsumoAlimentario.Models;

namespace ConsumoAlimentario.Repository.IRepository
{
    public interface IConsumoDiarioRepository
    {
        ICollection<ConsumoDiario> GetAll();
        ConsumoDiario Get(int id);
        ConsumoDiario Get(DateTime fecha);
        bool Guardar();
        bool CrearConsumoDiario(ConsumoDiario consumo);
        bool Existe(DateTime fecha);
    }
}
