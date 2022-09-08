namespace travel.Services.FlightAPI.Infrastructure;

public class FlightContext : DbContext, IUnitOfWork
{
    private readonly IMediator _mediator;
    public FlightContext(DbContextOptions<FlightContext> options, IMediator mediator) : base(options)
    {
        _mediator = mediator;
    }
    public DbSet<FlightItem> flightItems { get; set; }
    public DbSet<Handler> handlers { get; set; }
    public DbSet<Agency> agencies { get; set; }

    public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
    {
        await _mediator.DispatchDomainEventsAsync(this);

        int k = await this.SaveChangesAsync();
        return true;
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new FlightItemEntityTypeConfiguration());
        builder.ApplyConfiguration(new HandlerEntityTypeConfiguration());
        builder.ApplyConfiguration(new AgencyEntityTypeConfiguration());
        builder.ApplyConfiguration(new AgencyItemEntityTypeConfiguration());
    }
}


public class FlightContextDesignFactory : IDesignTimeDbContextFactory<FlightContext>
{
    public FlightContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<FlightContext>()
            .UseSqlServer("Server=.;Initial Catalog=FlightDb;Integrated Security=true");

        return new FlightContext(optionsBuilder.Options, new NoMediator());
    }
}

class NoMediator : IMediator
{
    public IAsyncEnumerable<TResponse> CreateStream<TResponse>(IStreamRequest<TResponse> request, CancellationToken cancellationToken = default)
    {
        return null;
    }

    public IAsyncEnumerable<object?> CreateStream(object request, CancellationToken cancellationToken = default)
    {
        return null;
    }

    public Task Publish(object notification, CancellationToken cancellationToken = default)
    {
        return Task.CompletedTask;
    }

    public Task Publish<TNotification>(TNotification notification, CancellationToken cancellationToken = default) where TNotification : INotification
    {
        return Task.CompletedTask;
    }

    public Task<TResponse> Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default)
    {
        return (Task<TResponse>)Task.CompletedTask;
    }

    public Task<object?> Send(object request, CancellationToken cancellationToken = default)
    {
        return (Task<object?>)Task.CompletedTask;
    }
}
