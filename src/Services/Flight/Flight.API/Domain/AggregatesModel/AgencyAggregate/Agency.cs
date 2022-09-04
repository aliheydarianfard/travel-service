namespace travel.Services.FlightAPI.Domain.AggregatesModel.AgencyAggregate;

    public class Agency:BaseEntity,IAggregateRoot
    {
        private string _agencyName;
        private int _handlerId;
        private readonly List<AgencyItem> _agencyItems;

        public Agency(string agencyName, int handlerId)
        {
            _agencyName = agencyName;
            _handlerId = handlerId;
            _agencyItems = new List<AgencyItem>();
        }
        public string AgencyName => _agencyName;
        public int HandlerId => _handlerId;
        public IReadOnlyCollection<AgencyItem> AgencyItems => _agencyItems;


        public void SetName(string? agencyName)
        {
            this._agencyName = agencyName ?? throw new FlightItemDomainException("Agency Name is required");
        }
        public void AggAgencyItem(int agencyId, int handlerId, int requestedNumber)
        {
            _agencyItems.Add(new AgencyItem(agencyId, handlerId, requestedNumber));    
        }
    }

