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

    [Route("items")]
    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> CreateAsync([FromBody] CreateFlightCommand command)
    {
        int id = await _mediator.Send(command);
        return Ok(id); 
    }



}

