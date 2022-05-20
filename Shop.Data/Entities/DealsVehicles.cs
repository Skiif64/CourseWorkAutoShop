using Shop.Data.Entities.Base;
using System;
using System.Collections.Generic;

namespace Shop.Data.Entities
{
    public class DealsVehicles : IEntity
    {
        public int Id { get; set; }
        public int DealId { get; set; }
        public int VehicleId { get; set; }
    }
}
