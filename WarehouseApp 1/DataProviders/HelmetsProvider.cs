using WarehouseApp.Repositores;
using WarehouseApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace WarehouseApp.DataProviders
{
    public class HelmetsProvider : IHelmetsProvider
    {
        private SqlRepository<Helmet> _helmetsRepository;

        public HelmetsProvider(SqlRepository<Helmet> helmetsRepository, DbContext warehouseAppDbContext)
        {
            _helmetsRepository = new SqlRepository<Helmet>(warehouseAppDbContext);
            _helmetsRepository = helmetsRepository;
            foreach (var item in GenerateSampleHelmet())
            {
                _helmetsRepository.Add(item);
            } 
        }
        public List<string> GetUniqueHelmetColors()
        {
            var helmets = _helmetsRepository.GetAll();
            var colors = helmets.Select(h => h.Color).Distinct().ToList();
            return colors;
        }
         public decimal GetMinimumPriceOfAllHelmets()
        {
            var helmets = _helmetsRepository.GetAll();
            
            return helmets.Select(h => h.ListPrice).Min();
        }

        public List<Helmet> OrderByName()
        {
            var helmets = _helmetsRepository.GetAll();
            return helmets.OrderBy(h => h.Name).ToList();
        }

        public List<Helmet> WhereColorIs(string color)
        {
            var equipments = _helmetsRepository.GetAll();
            return equipments.Where(x => x.Color == "Red").ToList();
        }

        public List<Helmet> GenerateSampleHelmet()
        {
            return new List<Helmet>
            {
            new Helmet
            {
                Id = 450,
                Name = "Helmet 1",
                Color = "Black",
                ListPrice = 320.5M,
                Type = "11"
            },
            new Helmet
            {
                Id = 455,
                Name = "Helmet 2",
                Color = "Green",
                ListPrice = 540.5M,
                Type = "12"
            },
            new Helmet
            {
                Id = 460,
                Name = "Helmet 3",
                Color = "Red",
                ListPrice = 340.5M,
                Type = "13"
            },
            new Helmet
            {
                Id = 465,
                Name = "Helmet 4",
                Color = "Black",
                ListPrice = 290.5M,
                Type = "14"
            },
            new Helmet
            {
                Id = 470,
                Name = "Helmet 5",
                Color = "Green",
                ListPrice = 210.5M,
                Type = "15"
            },
            new Helmet
            {
                Id = 475,
                Name = "Helmet 6",
                Color = "Black",
                ListPrice = 180.5M,
                Type = "16"
            },
            new Helmet
            {
                Id = 480,
                Name = "Helmet 7",
                Color = "Red",
                ListPrice = 340.5M,
                Type = "17"
            },
            new Helmet
            {
                Id = 485,
                Name = "Helmet 8",
                Color = "Red",
                ListPrice = 120.5M,
                Type = "18"
            },
            new Helmet
            {
                Id = 490,
                Name = "Helmet 9",
                Color = "Green",
                ListPrice = 530.5M,
                Type = "19"
            },
            new Helmet
            {
                Id = 495,
                Name = "Helmet 10",
                Color = "Red",
                ListPrice = 350.5M,
                Type = "20"
            },
            };
        }
    }
}
