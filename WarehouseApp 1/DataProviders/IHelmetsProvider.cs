using WarehouseApp.Entities;
using WarehouseApp.Repositores;

namespace WarehouseApp.DataProviders
{
    public interface IHelmetsProvider
    {
        List<string> GetUniqueHelmetColors();
        decimal GetMinimumPriceOfAllHelmets();
        List<Helmet> OrderByName();
        List<Helmet> WhereColorIs(string color);
        List<Helmet> GenerateSampleHelmet();
        IRepository<Helmet> GetHelmetRepo();
    }
}
