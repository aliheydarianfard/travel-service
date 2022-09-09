

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

    [Route("Create")]
    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.Created)]
    public async Task<IActionResult> CreateAsync([FromBody] CreateFlightCommand command)
    {
        int id = await _mediator.Send(command);
        return Ok(id); 
    }
    [Route("ChangePrice")]
    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.Created)]
    public async Task<IActionResult> ChangePrice([FromBody] UpdatePriceCommand command)
    {
        await _mediator.Send(command);
        return Ok();
    }




}

