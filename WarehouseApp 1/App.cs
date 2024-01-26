using WarehouseApp.Entities;
using WarehouseApp.Repositores;
using WarehouseApp.Comunication;
using WarehouseApp.DataProviders;

namespace WarehouseApp
{
    public class App : IApp
    {
        private readonly IUserComunication _userComunication;
        public App(IUserComunication userComunication)
        {
            _userComunication = userComunication;
        }
        public void Run()
        {
            _userComunication.Comunication();
        }
    }
}
