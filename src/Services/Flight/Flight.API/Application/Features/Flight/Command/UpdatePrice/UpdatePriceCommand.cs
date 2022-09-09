namespace travel.Services.FlightAPI.Appliction.Features.Flight.Command.UpdatePrice;
public class UpdatePriceCommand : IRequest
{
    public int Id { get; set; }
    public decimal Price { get; set; }
}

