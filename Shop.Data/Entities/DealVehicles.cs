using Shop.Data.Entities.Base;

namespace Shop.Data.Entities
{
    public class DealVehicles : IEntity
    {
        public int Id { get; set; }
        public int DealId { get; set; }
        public Deal Deal { get; set; }
        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }
    }
}
