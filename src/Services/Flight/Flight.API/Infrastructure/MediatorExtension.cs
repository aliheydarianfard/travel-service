namespace travel.Services.FlightAPI.Infrastructure;

public static class MediatorExtension
{
    public static async Task DispatchDomainEventsAsync(this IMediator mediator, FlightContext ctx)
    {
        var domainEntities = ctx.ChangeTracker.Entries<BaseEntity>()
            .Where(p => p.Entity.DomainEvents != null && p.Entity.DomainEvents.Any()).ToList();

        var domainEvents = domainEntities.SelectMany(p => p.Entity.DomainEvents).ToList();
        // clear Domain Events
        domainEntities.ForEach(e => e.Entity.ClearDomainEvents());

        // publish events
        foreach (var domainEvent in domainEvents)
        {
            await mediator.Publish(domainEvent);
        }

    }
}
