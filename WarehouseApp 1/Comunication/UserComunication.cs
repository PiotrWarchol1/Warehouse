using WarehouseApp.Data;
using WarehouseApp.Entities;
using WarehouseApp.Repositores;
using WarehouseApp1.DataProviders;
using WarehouseApp1.Entities;

namespace WarehouseApp1.Comunication
{
    public class UserComunication : IUserComunication
    {
        private readonly IRepository<Helmet> _helmetsRepository;
        private readonly IHelmetsProvider _helmetsProvider;

        public UserComunication(
            IRepository<Helmet> helmetsRepository,
            IHelmetsProvider helmetsProvider)
        {
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

            var equipmentRepository = GenerateEquipmentRepository();

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
                Console.WriteLine("Please provide the name of the equipment: Ski, Snowboard");
                bool ski = false;
                bool snowboard = false;
                string status = Console.ReadLine();

                if (status == "Ski")
                {
                    ski = true;
                }
                else if (status == "Snowboard")
                {
                    snowboard = false;
                }
                equipmentRepository.Add(new Equipment { Type = Console.ReadLine() });
                equipmentRepository.Save();
            }

            void WriteAllToConsole()
            {
                var _items = equipmentRepository.GetAll();
                foreach (var _item in _items)
                {
                    Console.WriteLine(_item);
                }
            }

            void RemoveEquipment()
            {
                Console.WriteLine("Enter the number of equipment you want to delete");
                try
                {
                    equipmentRepository.Remove(equipmentRepository.GetById(int.Parse(Console.ReadLine())));
                    equipmentRepository.Save();
                }
                catch
                {
                    Console.WriteLine("wrong option");

                }
            }

            void OrderByName()
            {
                Console.WriteLine("OrderByName");
                foreach (var helmet in _helmetsProvider.OrderByName())
                {
                    Console.WriteLine(helmet);
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
                foreach (var helmet in _helmetsProvider.WhereColorIs("Red"))
                {
                    Console.WriteLine(helmet);
                }
            }

            void GetUniqueHelmetColors()
            {
                Console.WriteLine();
                Console.WriteLine("GetUniqueHelmetColors");
                foreach (var helmet in _helmetsProvider.GetUniqueHelmetColors())
                {
                    Console.WriteLine(helmet);
                }
            }

            SqlRepository<Equipment> GenerateEquipmentRepository()
            {
                var repository = new SqlRepository<Equipment>(new WarehouseAppDbContext());
                repository.ItemAdded += EquipmentRepositoryOnItemAdded;
                repository.ItemRemove += EquipmentRepositoryOnItemRemove;
                return repository;
            }

            void GenerateHelmetsData(IRepository<Helmet> _helmetsRepository)
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
