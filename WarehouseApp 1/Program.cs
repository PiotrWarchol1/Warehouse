using Microsoft.Extensions.DependencyInjection;
using WarehouseApp.Entities;
using WarehouseApp.Repositores;
using WarehouseApp;
using WarehouseApp.Comunication;
using WarehouseApp.DataProviders;
using Microsoft.EntityFrameworkCore;
using WarehouseApp.Data;

var services = new ServiceCollection();
services.AddSingleton<IApp, App>();
services.AddSingleton<IHelmetsProvider, HelmetsProvider>();
services.AddSingleton<IUserComunication, UserComunication>();
services.AddSingleton<IRepository<Ski>, ListRepository<Ski>>();
services.AddSingleton<IRepository<Helmet>, ListRepository<Helmet>>();

var servicesProvider = services.BuildServiceProvider();
var app = servicesProvider.GetService<IApp>()!;
app.Run();
