namespace travel.Services.FlightAPI.Domain.AggregatesModel.FlightAggregate;
public class FlightItem : BaseEntity, IAggregateRoot
{
    private string _flightNumber;
    private decimal _price;
    private decimal _markup;
    private decimal _discount;
    private int _remain;
    private int _minimumquantity;
    private int _handlerId;
    private string _source;
    private string _destination;

    public FlightItem(string flightNumber, decimal price, decimal markup, decimal discount, int remain, int minimumquantity, int handlerId, string source,string destination)
    {
        _flightNumber = flightNumber ?? throw new FlightItemDomainException("The flight number is empty and must be entered");
        _price = price <= 0 ? throw new FlightItemDomainException("The price should be bigger than zero") : price;
        _markup = markup;
        _discount = discount;
        _remain = remain;
        _handlerId = handlerId;
        _minimumquantity = minimumquantity;
        _source = source ?? throw new FlightItemDomainException("The source can not be empty");
        _destination = destination ?? throw new FlightItemDomainException("The destination can not be empty");

    }

    public string FlightNumber => _flightNumber;
    public decimal Price => _price;
    public decimal Markup => _markup;
    public decimal Discount => _discount;
    public int Remain => _remain;
    public string Source => _source;
    public string Destination => _destination;
    public int HandlerId => _handlerId;
    public int Minimumquantity => _minimumquantity;
    public Handler handler { get; set; }

    public int AddFllightItem(int quantity)
    {
        if(_source==_destination)
            throw new FlightItemDomainException($"Source and destination must be diffrent");

        if (quantity < _remain)
        {
            _remain -= quantity;
        }
        return _remain;
    }
    public int RemoveFlight(int quantityDesired)
    {
        if (this._remain == 0)
        {
            throw new FlightItemDomainException($"Empty stock, flight item {FlightNumber} is sold out");
        }

        if (this._remain - quantityDesired < 0)
        {
            throw new FlightItemDomainException($"Item units desired should be greater than zero");
        }

        int removed = Math.Min(quantityDesired, this.Remain);

        this._remain -= removed;

        if (this._remain <= this._minimumquantity)
        {

            // Save Domain Event for publication at the time of storage
        }

        return removed;
    }
    public void SetDiscount(decimal discount)
    {

        if ((this.Price * 20 / 100) > discount)
        {
            throw new FlightItemDomainException($"More than 20% of the flight item price cannot be discounted ");
        }

        this._discount = discount;
    }
    public void UpdatePrice(decimal newPrice)
    {
        if (newPrice < 0)
            throw new FlightItemDomainException("The price should be bigger than zero");
        if (_price != newPrice)
        {
            //AddDomainEvent();
        }
        _price = newPrice;
    }

}

