using Microsoft.EntityFrameworkCore;
using WarehouseApp.Entities;

namespace WarehouseApp.Data
{
    public class WarehouseAppDbContext : DbContext
    { 
        public DbSet<Equipment> Equipment => Set<Equipment>();
        public DbSet<Helmet> Helmets => Set<Helmet>();


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseInMemoryDatabase("StorageAppDb");
        }
    }
}
