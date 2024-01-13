using Microsoft.EntityFrameworkCore;
using WarehouseApp.Entities;

namespace WarehouseApp.Data
{
    public class WarehouseAppDbContext : DbContext
    {
        public DbSet<Shoe> Shoe => Set<Shoe>();    
        public DbSet<Equipment> Equipment => Set<Equipment>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseInMemoryDatabase("StorageAppDb");
        }
    }
}
