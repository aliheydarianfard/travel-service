namespace travel.Services.FlightAPI.Infrastructure.Repositories;

    public class AgencyRepository:IAgencyRepository
    {
        private readonly FlightContext _context;
        public AgencyRepository(FlightContext context)
        {
            this._context = context ?? throw new ArgumentNullException(nameof(_context));
        }

        public IUnitOfWork UnitOfWork => _context;

        public Agency Add(Agency item)
        {
            return _context.Add(item).Entity;
        }

        public async Task<IEnumerable<Agency>> Get(int[] ids)
        {
            var items = await _context.agencies.Where(ci => ids.Contains(ci.Id)).ToListAsync();

            return items;
        }

        public async Task<Agency> GetByIdAsync(int id)
        {
            var agencies = await _context
                                  .agencies
                                  //.Include(ci => ci.SupplierItems)
                                  .FirstOrDefaultAsync(C => C.Id == id);

            return agencies;
        }
       

        public void Update(Agency item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }
    }

