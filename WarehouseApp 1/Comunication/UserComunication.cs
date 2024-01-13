using WarehouseApp.Data;
using WarehouseApp.Entities;
using WarehouseApp.Repositores;
using WarehouseApp1.DataProviders;
using WarehouseApp1.Entities;

namespace WarehouseApp1.Comunication
{
    public class UserComunication : IUserComunication
    {
        private readonly IRepository<Equipment> _equipmentsRepository;
        private readonly IRepository<Helmet> _helmetsRepository;
        private readonly IHelmetsProvider _helmetsProvider;

        public UserComunication(
            IRepository<Equipment> equipmentsRepository,
            IRepository<Helmet> helmetsRepository,
            IHelmetsProvider helmetsProvider)
        {
            _equipmentsRepository = equipmentsRepository;
            _helmetsRepository = helmetsRepository;
            _helmetsProvider = helmetsProvider;
        }
        public void Comunication()
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

            GenerateHelmetsData(_helmetsRepository);

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
                    case "4":
                        GetMinimumPriceOfAllHelmets(_helmetsProvider);
                        break;
                    case "5":
                        OrderByName(_helmetsProvider);
                        break;
                    case "6":
                        WhereColorIsRed(_helmetsProvider);
                        break;
                    case "7":
                        GetUniqueHelmetColors(_helmetsProvider);
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
                equipmentRepository.Add(new Equipment { Type = Console.ReadLine() });
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
            }

            static void OrderByName(IHelmetsProvider _helmetsProvider)
            {
                Console.WriteLine("OrderByName");
                foreach (var helmet in _helmetsProvider.OrderByName())
                {
                    Console.WriteLine(helmet);
                }
            }

            static void GetMinimumPriceOfAllHelmets(IHelmetsProvider _helmetsProvider)
            {
                Console.WriteLine();
                Console.WriteLine("GetMinimumPriceOfAllHelmets");
                Console.WriteLine(_helmetsProvider.GetMinimumPriceOfAllHelmets());
            }

            static void WhereColorIsRed(IHelmetsProvider _helmetsProvider)
            {
                Console.WriteLine();
                Console.WriteLine("WhereColorIs Red");
                foreach (var helmet in _helmetsProvider.WhereColorIs("Red"))
                {
                    Console.WriteLine(helmet);
                }
            }

            static void GetUniqueHelmetColors(IHelmetsProvider _helmetsProvider)
            {
                Console.WriteLine();
                Console.WriteLine("GetUniqueHelmetColors");
                foreach (var helmet in _helmetsProvider.GetUniqueHelmetColors())
                {
                    Console.WriteLine(helmet);
                }
            }

            static void GenerateHelmetsData(IRepository<Helmet> _helmetsRepository)
            {
                var helmets = HelmetsProvider.GenerateSampleHelmet();
                foreach (var helmet in helmets)
                {
                    _helmetsRepository.Add(helmet);
                }
            }
        }
    }

}
