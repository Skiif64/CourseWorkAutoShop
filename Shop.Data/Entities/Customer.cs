﻿using Shop.Data.Entities.Base;
using System;
using System.Collections.Generic;

namespace Shop.Data.Entities
{
    public class Customer : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Wallet { get; set; }
        public virtual ICollection<Deal> Deals { get; set; }
    }
}
