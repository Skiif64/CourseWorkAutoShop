using Shop.Data.Entities;
using Shop.Data.Repository.Base;

namespace Shop.Services.Base
{
    public interface IDataService
    {
        IRepository<Customer> Customers { get; }
        IRepository<Deal> Deals { get; }
        IRepository<ShipmentReport> ShipmentReports { get; }
        IRepository<ShipmentRequest> ShipmentRequests { get; }
        IRepository<Vehicle> Vehicles { get; }
        int Complete();
    }
}
