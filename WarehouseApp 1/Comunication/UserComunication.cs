using WarehouseApp.Entities;
using WarehouseApp.Repositores;
using WarehouseApp.DataProviders;
using WarehouseApp.Data;

namespace WarehouseApp.Comunication
{
    public class UserComunication : IUserComunication
    {
        private SqlRepository<Ski> _skiRepository;
        private SqlRepository<Helmet> _helmetsRepository;
        private WarehouseAppDbContext _warehouseAppDbContext;
        private IHelmetsProvider _helmetsProvider;

         public UserComunication(
            SqlRepository<Ski> skiRepository,
            SqlRepository<Helmet> helmetsRepository,
            WarehouseAppDbContext warehouseAppDbContext,
            IHelmetsProvider helmetsProvider)
         {
            _skiRepository = skiRepository;
            _helmetsRepository = helmetsRepository;
            _warehouseAppDbContext = warehouseAppDbContext;
            _helmetsProvider = helmetsProvider;
         }
         public void Comunication()
         {
            _skiRepository = new SqlRepository<Ski>(_warehouseAppDbContext);
            _helmetsRepository = new SqlRepository<Helmet>(_warehouseAppDbContext);

            ActivateEventListeners();

            ShowMenu();

            var quit = false;

            while (quit != true)
            {
                var input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        AddEquipment();
                        break;
                    case "2":
                        RemoveEquipment();
                        break;
                    case "3":
                        WriteAllToConsole();
                        break;
                    case "4":
                        GetMinimumPriceOfAllHelmets();
                        break;
                    case "5":
                        OrderByName();
                        break;
                    case "6":
                        WhereColorIsRed();
                        break;
                    case "7":
                        GetUniqueHelmetColors();
                        break;
                    case "q":
                        quit = true;
                        break;
                    default:
                        Console.WriteLine("wrong option");
                        break;
                }
            }
         }    
         void EquipmentRepositoryOnItemAdded(object? sender, Equipment e)
         {
             string equipment = ($"Data: {DateTime.Now}, Equipment added => {e.Type} from {sender?.GetType().Name}");
             Console.WriteLine(equipment);
             using (var writer = File.AppendText("Warehouse.txt"))
             {
                  writer.WriteLine(equipment);
             }
         }

         void EquipmentRepositoryOnItemRemove(object? sender, Equipment e)
         {
             string equipment = $"Date:  {DateTime.Now}, Equipment remove => {e.Type}  from {sender?.GetType().Name}";
             Console.WriteLine(equipment);
             using (var writer = File.AppendText("Warehouse.txt"))
             {
                  writer.WriteLine(equipment);
             }
         }

         void AddEquipment()
         {
             Console.WriteLine("Please provide the name of the equipment: Ski, Helmet");
             var item = Console.ReadLine();
             if (item.ToLower().Contains("ski"))
             {
             var ski = new Ski
             {
                  Type = item, Name = item, Color = "black", ListPrice = 1100 
             };
                    _skiRepository.Add(ski);
                    _skiRepository.Save();
         }
             else if (item.ToLower().Contains("helmet"))
                {
                    var helmet = new Helmet()
                    {
                        Type = item, Name = item, Color = "Red", ListPrice = 1200
                    };
                    _helmetsRepository.Add(helmet);
                    _helmetsRepository.Save();
                }
         }

         void WriteAllToConsole()
         {
             Show("SKIES", _skiRepository);
             Show("\nHELMET", _helmetsRepository);
         }
         void Show(string equipmentName, IReadRepository<Equipment> from)
         {
             Console.WriteLine(equipmentName + ":");
             foreach (var equipment in from.GetAll())
             {
                Console.WriteLine(equipment);
             }
         }

         void RemoveEquipment()
         {
             Console.WriteLine("Enter the number of equipment you want to delete");
             try
             {
                 _skiRepository.Remove(_skiRepository.GetById(int.Parse(Console.ReadLine())));
                 _skiRepository.Save();
             }
             catch
             {
                 Console.WriteLine("wrong option");

             }
             Console.WriteLine("Enter the number of equipment you want to delete");
             try
             {
                 _helmetsRepository.Remove(_helmetsRepository.GetById(int.Parse(Console.ReadLine())));
                 _helmetsRepository.Save();
             }
             catch
             {
                 Console.WriteLine("wrong option");

             }
         }

         void OrderByName()
         {
              Console.WriteLine("OrderByName");
              foreach (var equipment in _helmetsProvider.OrderByName())
              {
                  Console.WriteLine(equipment);
              }
         }

         void GetMinimumPriceOfAllHelmets()
         {
             Console.WriteLine();
             Console.WriteLine("GetMinimumPriceOfAllHelmets");
             Console.WriteLine(_helmetsProvider.GetMinimumPriceOfAllHelmets());
         }

         void WhereColorIsRed()
         {
              Console.WriteLine();
              Console.WriteLine("WhereColorIs Red");
              foreach (var equipment in _helmetsProvider.WhereColorIs("Red"))
              {
                   Console.WriteLine(equipment);
              }
         }

         void GetUniqueHelmetColors()
         {
             Console.WriteLine();
             Console.WriteLine("GetUniqueHelmetColors");
             foreach (var equipment in _helmetsProvider.GetUniqueHelmetColors())
             {
                 Console.WriteLine(equipment);
             }
         }
         void ShowMenu()
         {

             Console.WriteLine("----| Welcame to Warehause Application |----");
             Console.WriteLine("     ----------------------------------     ");
             Console.WriteLine("Warehause Application used to rent ski equipment");
             Console.WriteLine("------------------------------------------------");
             Console.WriteLine("Select what you want to do below by selecting the appropriate action number   ");
             Console.WriteLine("                                            ");
             Console.WriteLine("Press 1 if you want to return your equipment");
             Console.WriteLine("Press 2 if you want to rent equipment");
             Console.WriteLine("Press 3 if you want read the amount of equipment in the warehouse");
             Console.WriteLine("Press 4 if you want minimum price of all helmets");
             Console.WriteLine("Press 5 if you want by name");
             Console.WriteLine("Press 6 if you want color red");
             Console.WriteLine("Press 7 if you want unique helmet colors");
             Console.WriteLine("Press q if you want quit");
             Console.WriteLine("                        ");

         }

         void ActivateEventListeners()
         {
            _helmetsRepository.ItemAdded += EquipmentRepositoryOnItemAdded;
            _helmetsRepository.ItemRemove += EquipmentRepositoryOnItemRemove;

            _skiRepository.ItemAdded += EquipmentRepositoryOnItemAdded;
            _skiRepository.ItemRemove += EquipmentRepositoryOnItemRemove;
            _skiRepository.Save();

         }
        
    }

}
