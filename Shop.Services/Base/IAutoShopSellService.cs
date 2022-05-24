
using Shop.Data.Entities;
using Shop.Domain;
using System.Collections.Generic;

namespace Shop.Services.Base
{
    public interface IAutoShopSellService
    {
        void SellVehicle(VehiclesList vehicles);
    }
}
