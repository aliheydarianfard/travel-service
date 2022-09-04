namespace travel.Services.FlightAPI.Infrastructure;

public class FlightContext : DbContext
{
    public FlightContext(DbContextOptions<FlightContext> options) : base(options)
    {
    }
    public DbSet<FlightItem> flightItems { get; set; }
    public DbSet<Handler> handlers { get; set; }
    public DbSet<Agency> agencies { get; set; }

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

        return new FlightContext(optionsBuilder.Options);
    }
}
