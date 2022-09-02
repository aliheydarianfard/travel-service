namespace travel.Services.FlightAPI.Domain.Entity;
public class FlightItem
{
    public int Id { get; set; }
    public string FlightNumber { get; set; }
    public decimal Price { get; set; }
    public decimal? Markup { get; set; }
    public decimal? Discount { get; set; }
    public int Remain { get; set; }
    public int HandlerId { get; set; }
    public Handler Handler { get; set; }
}

