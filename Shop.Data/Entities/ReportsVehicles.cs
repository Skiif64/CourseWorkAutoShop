using Shop.Data.Entities.Base;
using System;
using System.Collections.Generic;

namespace Shop.Data.Entities
{
    public class ReportsVehicles : IEntity
    {
        public int Id { get; set; }
        public int ShipmentReportId { get; set; }
        public int VehicleId { get; set; }
    }
}
