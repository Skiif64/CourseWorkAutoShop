using Shop.Data.Entities;
using Shop.Data.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Data.Repository
{
    public class DealRepository : IRepository<Deal>
    {
        private ShopContext _db;
        private IRepository<Deal> _deals;
        private IRepository<Vehicle> _vehs;
        private IRepository<DealVehicles> _dealVehs;

        public DealRepository(ShopContext db)
        {
            _db = db;
            _deals = new Repository<Deal>(db);
            _vehs = new Repository<Vehicle>(db);
            _dealVehs = new Repository<DealVehicles>(db);
        }
        public void Add(Deal item)
        {
            _deals.Add(item);
        }

        public void AddRange(IEnumerable<Deal> items)
        {
            _deals.AddRange(items);
        }

        public IEnumerable<Deal> Find(Func<Deal, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Deal Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Deal> GetAll()
        {
            var deals = _deals.GetAll().ToList();
            var vehs = _vehs.GetAll().ToList();
            var dealVehs = _dealVehs.GetAll().ToList();
            
            foreach(var deal in deals)
            {               
                var v = dealVehs.Where(x=> x.DealId == deal.Id).Select(y=> y.Vehicle);                             
               
                deal.Vehicles = v.ToList();
            }
            return deals;
        }

        public void Remove(Deal item)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<Deal> items)
        {
            throw new NotImplementedException();
        }

        public void Update(Deal item)
        {
            throw new NotImplementedException();
        }

        public void UpdateRange(IEnumerable<Deal> items)
        {
            throw new NotImplementedException();
        }
    }
}
