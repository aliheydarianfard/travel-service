namespace travel.src.Services.Flight.Domain.SeedWork;


public interface IRepository<T>  
{
    IUnitOfWork UnitOfWork { get; }
}
