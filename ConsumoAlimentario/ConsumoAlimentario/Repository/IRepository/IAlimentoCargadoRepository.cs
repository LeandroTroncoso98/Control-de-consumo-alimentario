using ConsumoAlimentario.Models;
using ConsumoAlimentario.Models.Dto;

namespace ConsumoAlimentario.Repository.IRepository
{
    public interface IAlimentoCargadoRepository
    {
        bool Existe(int id);
        bool AgregarAlimento(AlimentoCargado alimentoCargado);
        bool Guardar();
        bool QuitarAlimento(AlimentoCargado alimentoCargado);
        AlimentoCargado CargarAlimentoDatos(AlimentoCargadoCrearDto alimentoCargadoCrearDto);
    }
}
