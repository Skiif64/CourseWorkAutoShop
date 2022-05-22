using Shop.Data.Entities;
using Shop.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Services
{
    public class AutoShopSellService
    {
        private IDataService _data;
        public AutoShopSellService(IDataService data)
        {
            _data = data;
        }
        public void SellVehicle(Customer customer, List<Vehicle> vehicles)
        {
            if (customer is null) throw new ArgumentNullException(nameof(customer), "Покупатель равен null.");
            if (vehicles.Count==0) throw new ArgumentNullException(nameof(vehicles), "Список автомобилей пуст.");
            var deal = CreateDeal(customer, vehicles);
            SaveDeal(deal);

        }

        private Deal CreateDeal(Customer customer, List<Vehicle> vehicles)
        {
            var deal = new Deal
            {
                Customer = customer,
                OfferTime = DateTime.Now,
                Vehicles = vehicles,
                TotalSum = vehicles.Sum(x => x.Price)
            };
            return deal;
        }        

        private void SaveDeal (Deal deal)
        {
            _data.Deals.Add(deal);
        }        
    }
}
