using Shop.Data.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Domain
{
    public class VehiclesOrder
    {
        public List<Vehicle> Vehicles;
        public string CustomerName { get; set; }
        public decimal TotalPrice
        {
            get
            {
                if (Count == 0) return 0;
                return Vehicles.Sum(x => x.Price);
            }
        }

        public int Count => Vehicles.Count;

        public void Add(Vehicle vehicle)
        {
            Vehicles.Add(vehicle);
        }

        public void Remove(Vehicle vehicle)
        {
            Vehicles.Remove(vehicle);
        }

    }
}
