using ConsumoAlimentario.Repository.IRepository;

namespace ConsumoAlimentario.Repository
{
    public class Repositorio<C> : IRepositorio<C> where C : class
    {
        public bool Actualizar(C entity)
        {
            throw new NotImplementedException();
        }

        public bool Borrar(C entity)
        {
            throw new NotImplementedException();
        }

        public C Get(C entity)
        {
            throw new NotImplementedException();
        }

        public ICollection<C> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Guardar()
        {
            throw new NotImplementedException();
        }
    }
}
