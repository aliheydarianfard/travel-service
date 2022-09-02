
namespace travel.Services.FlightAPI.Domain.AggregatesModel;

public class Handler : BaseEntity, IAggregateRoot
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

