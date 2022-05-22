
using Shop.Data.Entities;
using System.Collections.Generic;

namespace Shop.Services.Base
{
    public interface IAutoShopSellService
    {
        void SellVehicle(Customer customer, ICollection<Vehicle> vehicles);
    }
}
