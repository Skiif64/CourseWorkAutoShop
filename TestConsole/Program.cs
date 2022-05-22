using Shop.Data;
using Shop.Data.Entities;
using Shop.Services;
using System;
using System.Collections.Generic;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new ShopContext();
            var data = new DataService(db);
            var shopModel = new AutoShopSellService(data);

            var vehicle = new Vehicle
            {
                ManufacturerName = "Ваз",
                ModelName = "2109",
                Power = 78,
                Price = 80000,
                Count = 1
            };

            var customer = new Customer
            {
                Name = "Санек"
            };
            var vehicles = new List<Vehicle>();
            vehicles.Add(vehicle);
            shopModel.SellVehicle(customer, vehicles);
            data.Complete();
            var dealOut = data.Deals.GetAll();
            foreach(var d in dealOut)
            {
                Console.WriteLine($"Договор номер: {d.Id}");
                Console.WriteLine($"От: {d.OfferTime}");
                Console.WriteLine($"Покупатель: {d.Customer}");
                Console.WriteLine($"На сумму:  {d.TotalSum}");
                foreach(var v in d.Vehicles)
                {
                    Console.WriteLine($"Автомобиль: {v}");
                }
            }

        }
    }
}
