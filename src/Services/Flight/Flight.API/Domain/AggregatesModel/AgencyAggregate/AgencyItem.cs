namespace travel.Services.FlightAPI.Domain.AggregatesModel.AgencyAggregate;

    public class AgencyItem:BaseEntity
    {
        private int _agencyId;
        private int _requestedNumber;
        private int _handlerId;

        public AgencyItem()
        {
        }

        public AgencyItem(int agencyId, int handlerId, int requestedNumber)
        {
            this._agencyId = agencyId;
            this._handlerId = handlerId;
            this._requestedNumber = requestedNumber;
        }

        public int AgencyId => _agencyId;
        public int RequestedNumber => _requestedNumber;
        public int HandlerID => _handlerId;
    }

