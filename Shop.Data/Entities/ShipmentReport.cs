using Shop.Data.Entities.Base;
using System;
using System.Collections.Generic;

namespace Shop.Data.Entities
{
    public class ShipmentReport : IEntity
    {
        public int Id { get; set; }
        public DateTime ClosedTime { get; set; }
        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}
