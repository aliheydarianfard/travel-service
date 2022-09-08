namespace travel.Services.FlightAPI.Domain.Events;


public class FlightShortageHasOccurredDomainEvent : INotification
{
    public FlightShortageHasOccurredDomainEvent(int remain, FlightItem flightItem)
    {
        Remain = remain;
        this.flightItem = flightItem;
    }

    public int Remain { get; private set; }
    public FlightItem flightItem { get; private set; }
}

