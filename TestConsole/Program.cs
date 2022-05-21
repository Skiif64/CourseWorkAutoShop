using Shop.Data;
using Shop.Data.Entities;
using Shop.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new ShopContext();
            var customerRepository = new Repository<Customer>(db);
            var vehicleRepository = new Repository<Vehicle>(db);
            var dealRepository = new Repository<Deal>(db);

            var customer = new Customer
            {
                Name = "Санек"
            };
            var vehicle = new Vehicle
            {
                ManufacturerName = "Ваз",
                ModelName = "2109",
                Power = 78,
                Count = 1,
                Price = 80000
            };
            var vehicles = new List<Vehicle>();
            vehicles.Add(vehicle);
            var deal = new Deal
            {
                Customer = customer,
                OfferTime = DateTime.Now,
                Vehicles = vehicles,
                TotalSum = vehicles.Sum(x=> x.Price)
            };
            customerRepository.Add(customer);
            vehicleRepository.Add(vehicle);
            dealRepository.Add(deal);
            db.SaveChanges();

            Console.WriteLine($"Покупатель {customerRepository.GetAll().First()}");
            Console.WriteLine($"Авто {vehicleRepository.GetAll().First()}");
            var outdeal = dealRepository.GetAll().First();
            Console.WriteLine($"Договор номер {outdeal.Id} от {outdeal.OfferTime}");
            Console.WriteLine($"на сумму {outdeal.TotalSum}");
            Console.WriteLine($"покупатель {outdeal.Customer}");
            Console.WriteLine($"авто {outdeal.Vehicles.First(x=> x.Id==1)}");  
        }
    }
}
