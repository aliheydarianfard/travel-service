namespace travel.Services.FlightAPI.Infrastructure.Repositories;

    public class FlightRepository: IFlightRepository
{
    private readonly FlightContext _context;
    public FlightRepository(FlightContext context)
    {
        this._context = context ?? throw new ArgumentNullException(nameof(_context));
    }

    public IUnitOfWork UnitOfWork => _context;

    public FlightItem Add(FlightItem item)
    {
        return _context.Add(item).Entity;
    }

    public async Task<IEnumerable<FlightItem>> Get(int[] ids)
    {
        var items = await _context.flightItems.Where(ci => ids.Contains(ci.Id)).ToListAsync();

        return items;
    }

    public async Task<FlightItem> GetByIdAsync(int id)
    {
        var flightItems = await _context
                              .flightItems
                              //.Include(ci => ci.SupplierItems)
                              .FirstOrDefaultAsync(C => C.Id == id);

       
        return flightItems;
    }

    public async Task<IEnumerable<FlightItem>> GetFlightItems()
    {
        var itemsOnPage = await _context.flightItems
            .ToListAsync();

        return itemsOnPage;
    }

    public async Task<IEnumerable<FlightItem>> GetByHandler(int handlerId)
    {
        var items = await _context.flightItems.Where(p => p.HandlerId == handlerId).ToListAsync();
        return items;
    }

    public void Update(FlightItem item)
    {
        _context.Entry(item).State = EntityState.Modified;
    }

    
}

