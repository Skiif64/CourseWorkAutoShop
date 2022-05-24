using Shop.Data.Entities;
using Shop.Domain;
using Shop.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Services
{
    public class AutoShopSellService : IAutoShopSellService
    {
        private readonly IDataService _data;
        public AutoShopSellService(IDataService data)
        {
            _data = data;
        }       

        public void SellVehicle(VehiclesOrder vehicles)
        {
            if (vehicles.CustomerName is null) throw new ArgumentNullException(nameof(vehicles.CustomerName), "Покупатель равен null.");
            if (vehicles.Count == 0) throw new ArgumentNullException(nameof(vehicles), "Список автомобилей пуст.");
            var deal = CreateDeal(vehicles.CustomerName, vehicles.Vehicles);
            SaveDeal(deal);
        }

        private Deal CreateDeal(string customerName, ICollection<Vehicle> vehicles)
        {
            var deal = new Deal
            {
                Customer = customerName,
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
