using Shop.Data;
using Shop.Data.Entities;
using Shop.Data.Repository;
using Shop.Data.Repository.Base;
using Shop.Services.Base;
using System;
using System.Collections.Generic;

namespace Shop.Services
{
    public class DataService : IDataService
    {
        private readonly ShopContext _db;
        
        public IRepository<Deal> Deals { get; }
        public IRepository<DealVehicles> DealVehicles { get; }
       
        public IRepository<Vehicle> Vehicles { get; }

        public DataService(ShopContext db)
        {
            _db = db;
            
            Deals = new DealRepository(db);
            DealVehicles = new Repository<DealVehicles>(db);            
            Vehicles = new Repository<Vehicle>(db);
        }
        public int Complete()
        {
            return _db.SaveChanges();
        }
    }
}
