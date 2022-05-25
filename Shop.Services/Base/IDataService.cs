using Shop.Data.Entities;
using Shop.Data.Repository.Base;

namespace Shop.Services.Base
{
    public interface IDataService
    {
        
        IRepository<Deal> Deals { get; }
        IRepository<DealVehicles> DealVehicles { get; }        
        IRepository<Vehicle> Vehicles { get; }
        int Complete();
    }
}
