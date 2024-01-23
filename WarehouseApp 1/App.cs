using WarehouseApp.Entities;
using WarehouseApp.Repositores;
using WarehouseApp.Comunication;
using WarehouseApp.DataProviders;

namespace WarehouseApp
{
    public class App : IApp
    {
        private readonly IUserComunication _userComunication;
        private readonly IRepository<Equipment> _equipmentsRepository;
        private readonly IRepository<Helmet> _helmetsRepository;
        private readonly IHelmetsProvider _helmetsProvider;
        public App(
            IUserComunication userComunication,
            IRepository<Equipment> equipmentsRepository, 
            IRepository<Helmet> helmetsRepository,
            IHelmetsProvider helmetsProvider) 
        {
            _userComunication = userComunication;
            _equipmentsRepository = equipmentsRepository;
            _helmetsRepository = helmetsRepository;
            _helmetsProvider = helmetsProvider;
        }
        public void Run()
        {
            _userComunication.Comunication();
        }
    }
}
