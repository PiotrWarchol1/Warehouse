using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseApp1.Entities;

namespace WarehouseApp1.DataProviders.Extensions
{
    public static class HelmetHelper
    {
        public static IEnumerable<Helmet> ByColor(this IEnumerable<Helmet> query, string color)
        {
            return query.Where(h => h.Color == color);
        }

    }
}
