using Microsoft.EntityFrameworkCore;
using WarehouseApp.Entities;

namespace WarehouseApp.Data
{ 
    public class WarehouseAppDbContext : DbContext
    { 
        public DbSet<Helmet> Helmets => Set<Helmet>();
        public DbSet<Ski> Skis => Set<Ski>();
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseInMemoryDatabase("StorageAppDb");
        }
    }
}
