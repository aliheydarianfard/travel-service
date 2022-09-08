using System.Net;

namespace travel.Services.FlightAPI.Controllers;


[Route("api/v1/[controller]")]
[ApiController]
public class FlightController : ControllerBase
{
    private readonly IMediator _mediator;
    public FlightController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateFlightCommand command)
    {
        int id = await _mediator.Send(command);
        return Ok(id); 
    }



}

