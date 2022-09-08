namespace travel.Services.FlightAPI.Appliction.Features.Flight.Command.CreateFlight;
public class CreateFlightCommand : IRequest<int>
{
    public CreateFlightCommand()
    {
    }

    [JsonConstructor]
    public CreateFlightCommand(string flightNumber, decimal price, decimal markup, decimal discount, int remain, string source, string destination, int minimumquantity, int handlerId)
    {
        FlightNumber = flightNumber;
        Price = price;
        Markup = markup;
        Discount = discount;
        Remain = remain;
        Source = source;
        Destination = destination;
        Minimumquantity = minimumquantity;
        HandlerId = handlerId;
    }

    [JsonProperty]
    public string FlightNumber { get;  set; }
    [JsonProperty]
    public decimal Price { get;  set; }
    [JsonProperty]
    public decimal Markup { get;  set; }
    [JsonProperty]
    public decimal Discount { get;  set; }
    [JsonProperty]
    public int Remain { get;  set; }
    [JsonProperty]
    public string Source { get;  set; }
    [JsonProperty]
    public string Destination { get;  set; }
    [JsonProperty]
    public int Minimumquantity { get;  set; }
    [JsonProperty]
    public int HandlerId { get;  set; }
}

