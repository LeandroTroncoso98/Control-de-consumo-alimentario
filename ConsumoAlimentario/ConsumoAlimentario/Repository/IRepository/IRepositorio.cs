namespace ConsumoAlimentario.Repository.IRepository
{
    public interface IRepositorio<C> where C : class
    {
        bool Guardar();
        bool Actualizar(C entity);
        bool Borrar(C entity);
        C Get(C entity);
        ICollection<C> GetAll();
    }
}
