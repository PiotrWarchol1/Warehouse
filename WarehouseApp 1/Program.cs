using Microsoft.Extensions.DependencyInjection;
using WarehouseApp.Entities;
using WarehouseApp.Repositores;
using WarehouseApp;
using WarehouseApp.Comunication;
using WarehouseApp.DataProviders;

var services = new ServiceCollection();
services.AddSingleton<IApp, App>();
services.AddSingleton<IRepository<Equipment>, ListRepository<Equipment>>();
services.AddSingleton<IRepository<Helmet>, ListRepository<Helmet>>();
services.AddSingleton<IHelmetsProvider, HelmetsProvider>();
services.AddSingleton<IUserComunication, UserComunication>();


var servicesProvider = services.BuildServiceProvider();
var app = servicesProvider.GetService<IApp>()!;
app.Run();



/*using System.ComponentModel.Design;
using WarehouseApp.Data;
using WarehouseApp.Entities;
using WarehouseApp.Repositores;
using WarehouseApp.Repositores.Extensions;*/
/*
Console.WriteLine("----| Welcame to Warehause Application |----");
Console.WriteLine("     ----------------------------------     ");
Console.WriteLine("Warehause Application used to rent ski equipment");
Console.WriteLine("------------------------------------------------");
Console.WriteLine("Select what you want to do below by selecting the appropriate action number   ");
Console.WriteLine("                                            ");
Console.WriteLine("Press 1 if you want to return your equipment");
Console.WriteLine("Press 2 if you want to rent equipment");
Console.WriteLine("Press 3 if you want read the amount of equipment in the warehouse");
Console.WriteLine("Press 4 if you want to close application");
Console.WriteLine("                                            ");

var equipmentRepository = new SqlRepository<Equipment>(new WarehouseAppDbContext());
equipmentRepository.ItemAdded += EquipmentRepositoryOnItemAdded;
equipmentRepository.ItemRemove += EquipmentRepositoryOnItemRemove;

do 
{
    string input = Console.ReadLine();
    if (input == "q")
        break;

    switch (input)
    {
        case "1":            
            AddEquipment(equipmentRepository);
            break;
        case "2":
            RemoveEquipment(equipmentRepository);
            break;
        case "3":
            WriteAllToConsole(equipmentRepository);
            break;
        default:
            Console.WriteLine("wrong option");
            break;
    }
} while (true);


static void EquipmentRepositoryOnItemAdded(object? sender, Equipment e)
{
    string equipment = ($"Data: {DateTime.Now}, Equipment added => {e.Type} from {sender?.GetType().Name}");
    Console.WriteLine(equipment);
    using (var writer = File.AppendText("Warehouse.txt"))
    {
        writer.WriteLine(equipment);
    }
}

static void EquipmentRepositoryOnItemRemove(object? sender, Equipment e)
{
    string equipment = $"Date:  {DateTime.Now}, Equipment remove => {e.Type}  from {sender?.GetType().Name}";
    Console.WriteLine(equipment);
    using (var writer = File.AppendText("Warehouse.txt"))
    {
        writer.WriteLine(equipment);
    }
}


static void AddEquipment(IRepository<Equipment> equipmentRepository)
{
    Console.WriteLine("Please provide the name of the equipment: Ski, Snowboard");
    bool skiStatus = false;
    bool snowboardStatus = false;
    string status = Console.ReadLine();  

    if (status == "Ski")
    {
        skiStatus = true;
    }
    else if (status == "Snowboard")
    {
        snowboardStatus = false;
    }
    equipmentRepository.Add(new Equipment {Type = Console.ReadLine() });
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

static void RemoveEquipment(IRepository<Equipment> repository)
{
    Console.WriteLine("Enter the number of equipment you want to delete");
    try
    {
        repository.Remove(repository.GetById(int.Parse(Console.ReadLine())));
        repository.Save();
    }
    catch
    {
        Console.WriteLine("wrong option");

    }
}*/