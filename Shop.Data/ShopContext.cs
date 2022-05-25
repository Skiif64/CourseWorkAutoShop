using Microsoft.EntityFrameworkCore;
using Shop.Data.Entities;

namespace Shop.Data
{  
    public class ShopContext : DbContext
    {
        private readonly string _connectionString;
        
        public DbSet<Deal> Deals { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<DealVehicles> DealVehicles { get; set; }

        public ShopContext()
        {
            _connectionString = ConnectionStringLoader.GetDBAdress();
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
