
namespace travel.Services.FlightAPI.Domain.AggregatesModel.FlightAggregate;

public class Handler : BaseEntity
{
    private string _name;
    private string? _desc;

    public Handler(string name, string? desc)
    {
        _name = name;
        _desc = desc;
    }

    public string Name => _name;
    public string? Desc => _desc;
}

