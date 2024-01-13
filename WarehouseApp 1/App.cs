using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseApp.Entities;
using WarehouseApp.Repositores;
using WarehouseApp1.Comunication;
using WarehouseApp1.DataProviders;
using WarehouseApp1.Entities;

namespace WarehouseApp1
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
