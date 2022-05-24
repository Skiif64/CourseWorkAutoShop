using Shop.Data;
using Shop.Data.Entities;
using Shop.Domain;
using Shop.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestConsole
{
    class Program
    {
        static async Task Main(string[] args)
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
            var order = new VehiclesOrder
            {
                Customer = customer,
                Vehicles = vehicles
            };
            shopModel.SellVehicle(order);
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

            var requesterModel = new AutoShopRequestVehicleService(data);
            await requesterModel.CreateRequest(vehicles);
            requesterModel.WaitTime = 10000;

            foreach(var req in data.ShipmentRequests.GetAll())
            {
                Console.WriteLine($"Заказ номер: {req.Id}");
                Console.WriteLine($"Дата заказа: {req.OpenTime}");
                foreach(var v in req.Vehicles)
                {
                    Console.WriteLine($"Автомобиль: {v}");
                }
            }

            foreach (var rep in data.ShipmentReports.GetAll())
            {
                Console.WriteLine($"Постака номер: {rep.Id}");
                Console.WriteLine($"Дата поставки: {rep.ClosedTime}");
                foreach (var v in rep.Vehicles)
                {
                    Console.WriteLine($"Автомобиль: {v}");
                }
            }

        }
    }
}
