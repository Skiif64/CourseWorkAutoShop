using Shop.Data.Entities.Base;
using System;
using System.Collections.Generic;


namespace Shop.Data.Entities
{
    public class RequestsVehicles : IEntity
    {
        public int Id { get; set; }
        public int ShipmentRequestId { get; set; }
        public int VehicleId { get; set; }
    }
}
