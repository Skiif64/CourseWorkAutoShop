using Shop.Data.Entities.Base;
using System;
using System.Collections.Generic;

namespace Shop.Data.Entities
{
    public class Deal : IEntity
    {
        public int Id { get; set; }
        public string Customer { get; set; }
        public virtual ICollection<Vehicle> Vehicles { get; set; }
        public DateTime OfferTime { get; set; }
        public decimal TotalSum { get; set; }
    }
}
