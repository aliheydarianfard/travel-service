namespace travel.Services.FlightAPI.Domain.Exceptions;

    public class FlightItemDomainException : Exception
    {
        public FlightItemDomainException()
        { }

        public FlightItemDomainException(string message)
            : base(message)
        { }

        public FlightItemDomainException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }

