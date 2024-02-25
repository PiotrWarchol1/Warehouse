using WarehouseApp.Entities;

namespace WarehouseApp.Repositores
{
    public class ListRepository<T> : IRepository<T> where T : class, IEntity, new()
    {
        protected readonly List<T> _items = new();

        public event EventHandler<T>? ItemAdded;
        public event EventHandler<T>? ItemRemove;
        public IEnumerable<T> GetAll()
        {
            return _items.ToList();
        }
        public T GetById(int id)
        {
            return _items.Single(_item => _item.Id == id);
        }
        public void Add(T _item)
        {
            _item.Id = _items.Count + 1;
            _items.Add(_item);
        }       
        public void Remove(T _item)
        {
            _items.Remove(_item);
        }
        public void Save()
        {
        } 

    }
}
