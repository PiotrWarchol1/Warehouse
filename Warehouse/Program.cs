using WarehouseApp.Data;
using WarehouseApp.Entities;
using WarehouseApp.Repositores;

var equipmentRepository = new SqlRepository<Equipment>(new WarehouseAppDbContext());
AddShoes(equipmentRepository);
AddEquipments(equipmentRepository);
WriteAllToConsole(equipmentRepository);

static void AddEquipments(IRepository<Equipment> equipmentRepository)
{
    equipmentRepository.Add(new Equipment { Type = "Ski" });
    equipmentRepository.Add(new Equipment { Type = "Snowboard" });
    equipmentRepository.Save();
}
static void AddShoes(IWriteRepository<Shoe> shoeRepository)
{
    shoeRepository.Add(new Shoe { Person = "Child" });
    shoeRepository.Add(new Shoe { Person = "Child" });
    shoeRepository.Add(new Shoe { Person = "Adult" });
    shoeRepository.Save();
}

static void WriteAllToConsole(IReadRepository<IEntity> repository)
{
    var _items = repository.GetAll();
    foreach (var _item in _items)
    {
        Console.WriteLine(_item);
    }
}