using System.Text.Json;
using WarehouseApp.Entities;

namespace WarehouseApp.Repositores
{
    public class ListRepository<T> : IRepository<T> where T : class, IEntity, new()
    {
        private List<T> _items = new List<T>();

        public event EventHandler<T>? ItemAdded;
        public event EventHandler<T>? ItemRemove;
        public IEnumerable<T> GetAll()
        {
            if (File.Exists("items.json"))
            {
                using (var reader = File.OpenText("items.json"))
                {
                    var line = reader.ReadLine();
                    _items = JsonSerializer.Deserialize<List<T>>(line);
                }
            }
            return _items;
        }
        public T GetById(int id)
        {
            return _items[id-1];
        }
        public void Add(T _item)
        {
            _items.Add(_item);
            _item.Id = _items.Count;
            ItemAdded?.Invoke(this, _item);
        }       
        public void Remove(T _item)
        {
            _items.RemoveAt(_item.Id - 1);
            for (int i = 0; i < _items.Count; i++)
            {
                _items[i].Id = i + 1;
            }
            ItemRemove?.Invoke(this, _item);
        }
        public void Save()
        {
            using (StreamWriter writer = new StreamWriter($"items.json", false))
            {
                var json = JsonSerializer.Serialize(_items);
                writer.WriteLine(json);
            }
        }
    }
}
