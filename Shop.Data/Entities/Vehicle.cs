using Shop.Data.Entities.Base;
using System;
using System.Collections.Generic;

namespace Shop.Data.Entities
{
    public class Vehicle : IEntity
    {
        public int Id { get; set; }
        public string ModelName { get; set; }
        public string ManufacturerName { get; set; }
        public int Power { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
        public virtual ICollection<Deal> Deals { get; set; }       

        public override string ToString()
        {
            return $"{ManufacturerName} {ModelName}";
        }
    }
}
