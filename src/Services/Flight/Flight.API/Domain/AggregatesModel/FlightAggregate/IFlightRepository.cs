namespace travel.Services.FlightAPI.Domain.AggregatesModel.FlightAggregate
{
    public interface IFlightRepository:IRepository<FlightItem> 
    {
        FlightItem Add(FlightItem item);
        void Update(FlightItem item);
        Task<IEnumerable<FlightItem>> Get(int[] ids);
        Task<IEnumerable<FlightItem>> GetByHandler(int handler);
        Task<FlightItem> GetByIdAsync(int id);
        Task<IEnumerable<FlightItem>> GetFlightItems();
    }
}
