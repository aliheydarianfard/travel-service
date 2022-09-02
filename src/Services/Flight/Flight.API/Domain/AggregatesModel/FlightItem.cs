namespace travel.Services.FlightAPI.Domain.AggregatesModel;
public class FlightItem : BaseEntity, IAggregateRoot
{
    private string _flightNumber;
    private decimal _price;
    private decimal _markup;
    private decimal _discount;
    private int _remain;
    private int _stockThreshold;
    private int _handlerId;

    public FlightItem(string flightNumber, decimal price, decimal markup, decimal discount, int remain, int stockThreshold, int handlerId)
    {
        _flightNumber = flightNumber ?? throw new FlightItemDomainException("The flight number is empty and must be entered");
        _price = price <= 0 ? throw new FlightItemDomainException("The price should be bigger than zero") : price;
        _markup = markup;
        _discount = discount;
        _remain = remain;
        _handlerId = handlerId;
        _stockThreshold = stockThreshold;
    }

    public string FlightNumber => _flightNumber;
    public decimal Price => _price;
    public decimal Markup => _markup;
    public decimal Discount => _discount;
    public int Remain => _remain;
    public int HandlerId => _handlerId;
    public int StockThreshold => _stockThreshold;
    public Handler Handler { get; set; }

    public int AddFllightItem(int quantity)
    {
        int orginal = this._remain;

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

        if (this._remain <= this._stockThreshold)
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


}

