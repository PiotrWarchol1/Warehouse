using WarehouseApp.Entities;

namespace WarehouseApp.DataProviders.Extensions
{
    public static class HelmetHelper
    {
        public static IEnumerable<Helmet> ByColor(this IEnumerable<Helmet> query, string color)
        {
            return query.Where(h => h.Color == color);
        }

    }
}
