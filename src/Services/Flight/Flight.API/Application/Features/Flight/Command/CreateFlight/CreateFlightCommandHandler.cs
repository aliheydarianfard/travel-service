namespace Flight.API.Application.Features.Flight.Command.CreateFlight
{
    internal class CreateFlightCommandHandler : IRequestHandler<CreateFlightCommand, int>
    {
        private readonly IFlightRepository _flightRepository;
        private readonly ILogger<CreateFlightCommandHandler> _logger;

        public CreateFlightCommandHandler(IFlightRepository flightRepository, ILogger<CreateFlightCommandHandler> logger)
        {
            _flightRepository = flightRepository ?? throw new ArgumentException(nameof(flightRepository));
            _logger = logger ?? throw new ArgumentException(nameof(logger)); ;
        }

        public async Task<int> Handle(CreateFlightCommand request, CancellationToken cancellationToken)
        {
            var flightItem = new FlightItem(flightNumber: request.FlightNumber, price: request.Price, markup: request.Markup, discount: request.Discount
                , remain: request.Remain, minimumquantity: request.Minimumquantity, handlerId: request.HandlerId,
                source: request.Source, destination: request.Destination);
            _flightRepository.Add(flightItem);

            await _flightRepository.UnitOfWork.SaveEntitiesAsync();
            _logger.LogInformation("-----  Flight Create - Flight: {@flight}", flightItem);
            return flightItem.Id;
        }
    }
}
