using Shop.Data.Entities.Base;
using System;
using System.Collections.Generic;

namespace Shop.Data.Entities
{
    public class Deal : IEntity
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public virtual ICollection<DealsVehicles> Deals { get; set; }
        public DateTime OfferTime { get; set; }
        public decimal TotalSum { get; set; }
    }
}
