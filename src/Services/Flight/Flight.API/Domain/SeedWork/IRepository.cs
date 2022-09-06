namespace travel.Services.FlightAPI.Domain.SeedWork;


public interface IRepository<T>  
{
    IUnitOfWork UnitOfWork { get; }
}
