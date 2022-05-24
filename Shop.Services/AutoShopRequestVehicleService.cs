using Shop.Data.Entities;
using Shop.Services.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shop.Services
{
    public class AutoShopRequestVehicleService
    {
        private readonly IDataService _data;
        public int WaitTime { get; set; }

        public AutoShopRequestVehicleService(IDataService data)
        {
            _data = data;
        }

        public async Task CreateRequest(ICollection<Vehicle> vehicles)
        {
            var request = new ShipmentRequest
            {
                OpenTime = DateTime.Now,
                Vehicles = vehicles
            };
            _data.ShipmentRequests.Add(request);
            await Task.Delay(WaitTime);
            var report = new ShipmentReport
            {
                ClosedTime = DateTime.Now,
                Vehicles = vehicles
            };
            _data.ShipmentReports.Add(report);

            _data.Complete();
        }
    }
}
