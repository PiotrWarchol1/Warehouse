using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseApp1.Entities;

namespace WarehouseApp1.DataProviders
{
    public interface IHelmetsProvider
    {
        List<string> GetUniqueHelmetColors();
        decimal GetMinimumPriceOfAllHelmets();
        List<Helmet> OrderByName();
        List<Helmet> WhereColorIs(string color);
    }
}
