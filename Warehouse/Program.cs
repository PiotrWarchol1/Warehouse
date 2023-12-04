using WarehouseApp.Data;
using WarehouseApp.Entities;
using WarehouseApp.Repositores;

var shoeRepository = new SqlRepository<Shoe>(new WarehouseAppDbContext());
AddShoes(shoeRepository);
AddEquipments(shoeRepository);
WriteAllToConsole(shoeRepository);

static void AddShoes(IRepository<Shoe> shoeRepository)
{
    shoeRepository.Add(new Shoe { Person = "Child" });
    shoeRepository.Add(new Shoe { Person = "Child" });
    shoeRepository.Add(new Shoe { Person = "Adult" });
    shoeRepository.Save();
}
static void AddEquipments(IWriteRepository<Equipment> equipmentRepository)
{
    equipmentRepository.Add(new Equipment { Type = "Ski" });
    equipmentRepository.Add(new Equipment { Type = "Snowboard" });
    equipmentRepository.Save();
}
static void WriteAllToConsole(IReadRepository<IEntity> repository)
{
    var _items = repository.GetAll();
    foreach (var _item in _items)
    {
        Console.WriteLine(_item);
    }
}