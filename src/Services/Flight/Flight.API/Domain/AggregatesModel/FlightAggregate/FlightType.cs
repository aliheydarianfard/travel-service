
namespace travel.Services.FlightAPI.Domain.AggregatesModel.FlightAggregate;

public class FlightType : BaseEntity, IAggregateRoot
{
    private string _name;
    private string? _desc;

    public FlightType(string name, string? desc)
    {
        _name = name;
        _desc = desc;
    }

    public string Name => _name;
    public string? Desc => _desc;
}

