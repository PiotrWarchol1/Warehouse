using WarehouseApp.Entities;

namespace WarehouseApp.DataProviders
{
    public interface IHelmetsProvider
    {
        List<string> GetUniqueHelmetColors();
        decimal GetMinimumPriceOfAllHelmets();
        List<Helmet> OrderByName();
        List<Helmet> WhereColorIs(string color);
    }
}
