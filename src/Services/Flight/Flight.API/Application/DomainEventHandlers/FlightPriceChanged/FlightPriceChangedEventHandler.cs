namespace travel.Services.FlightAPI.Appliction.DomainEventHandlers.FlightPriceChanged
{
    public class FlightPriceChangedEventHandler : INotificationHandler<FlightPriceChangedDomainEvent>
    {
        private readonly ILoggerFactory _logger;

        public FlightPriceChangedEventHandler(ILoggerFactory logger)
        {
            _logger = logger;
        }

        public Task Handle(FlightPriceChangedDomainEvent notification, CancellationToken cancellationToken)
        {
            _logger.CreateLogger<FlightPriceChangedDomainEvent>()
           .LogTrace("Catalog with Id: {flightId} has been successfully updated to new Price",
               notification?.FlightItem?.Id);

            // Dispatch Integration Event
            return Task.CompletedTask;
        }
    }
}
