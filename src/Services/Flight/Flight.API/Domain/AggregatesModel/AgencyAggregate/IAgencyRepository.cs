namespace travel.Services.FlightAPI.Domain.AggregatesModel.AgencyAggregate
{
    public interface IAgencyRepository : IRepository<Agency>
    {
        Agency Add(Agency item);
        void Update(Agency item);
        Task<IEnumerable<Agency>> Get(int[] id);
        Task<Agency> GetByIdAsync(int id);
    }
}
