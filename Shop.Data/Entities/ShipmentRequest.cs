using Shop.Data.Entities.Base;
using System;
using System.Collections.Generic;

namespace Shop.Data.Entities
{
    public class ShipmentRequest : IEntity
    {
        public int Id { get; set; }
        public DateTime OpenTime { get; set; }
        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}
