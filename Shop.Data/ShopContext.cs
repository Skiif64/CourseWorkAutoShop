using Microsoft.EntityFrameworkCore;
using Shop.Data.Entities;

namespace Shop.Data
{  
    public class ShopContext : DbContext
    {
        private readonly string _connectionString = @"Server=localhost\SQLEXPRESS;Database=AutoShop;Trusted_Connection=True;";
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Deal> Deals { get; set; }
        public DbSet<DealsVehicles> DealsVehicles { get; set; }
        public DbSet<ReportsVehicles> ReportsVehicles { get; set; }
        public DbSet<RequestsVehicles> RequestsVehicles { get; set; }
        public DbSet<ShipmentReport> ShipmentReports { get; set; }
        public DbSet<ShipmentRequest> ShipmentRequests { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        
        public ShopContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
