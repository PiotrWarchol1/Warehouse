using WarehouseApp.Entities;

namespace WarehouseApp.Repositores
{
    public interface IReadRepository<out T> where T : class, IEntity 
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
    }
}
