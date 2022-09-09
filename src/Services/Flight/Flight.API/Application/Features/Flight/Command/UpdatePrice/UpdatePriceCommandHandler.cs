namespace travel.Services.FlightAPI.Appliction.Features.Flight.Command.UpdatePrice;
public class UpdatePriceCommandHandler : IRequestHandler<UpdatePriceCommand>
{
    private readonly IFlightRepository _flightRepository;
    private readonly ILogger<UpdatePriceCommandHandler> _logger;

    public UpdatePriceCommandHandler(IFlightRepository flightRepository, ILogger<UpdatePriceCommandHandler> logger)
    {
        _flightRepository = flightRepository ?? throw new ArgumentException(nameof(flightRepository));
        _logger = logger ?? throw new ArgumentException(nameof(logger)); ;
    }
    public async Task<Unit> Handle(UpdatePriceCommand request, CancellationToken cancellationToken)
    {
        var flightItem = await _flightRepository.GetByIdAsync(request.Id);

        if (flightItem == null)
            throw new NotFoundException(nameof(flightItem), request.Id);
        
        flightItem.UpdatePrice(request.Price);
        await _flightRepository.UnitOfWork.SaveEntitiesAsync();

        _logger.LogInformation("-----  flight Price Update - Catalog: {@flight}", flightItem);
        return Unit.Value;
    }
}

