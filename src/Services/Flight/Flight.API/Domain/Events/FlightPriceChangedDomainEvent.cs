namespace travel.Services.FlightAPI.Domain.Events;

public class FlightPriceChangedDomainEvent : INotification
{
    public FlightPriceChangedDomainEvent(decimal newPrice, decimal oldPrice, FlightItem flightItem)
    {
        NewPrice = newPrice;
        OldPrice = oldPrice;
        FlightItem = flightItem;
    }

    public decimal NewPrice { get; private set; }
    public decimal OldPrice { get; set; }
    public FlightItem FlightItem { get; private set; }
}

