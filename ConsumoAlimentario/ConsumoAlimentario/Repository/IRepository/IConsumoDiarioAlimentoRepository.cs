using ConsumoAlimentario.Models;

namespace ConsumoAlimentario.Repository.IRepository
{
    public interface IConsumoDiarioAlimentoRepository
    {
        bool Guardar();
        bool AgregarAlimentoAConsumo(ConsumoDiarioAlimento consumoDiarioAlimento);
        bool QuitarAlimentoAConsumo(ConsumoDiarioAlimento consumoDiarioAlimento);
    }
}
