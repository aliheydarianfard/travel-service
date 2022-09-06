using System.Net;

namespace travel.Services.FlightAPI.Controllers;


[Route("api/v1/[controller]")]
[ApiController]
public class FlightController : ControllerBase
{
    private readonly IFlightRepository _flightRepository;

    public FlightController(IFlightRepository flightRepository)
    {
        _flightRepository = flightRepository;
    }

    [HttpGet]
    [Route("Items")]
    [ProducesResponseType(typeof(IEnumerable<FlightItem>), (int)HttpStatusCode.OK)]
    public async  Task<IActionResult> ItemsAsync()
    {
        var _list =await _flightRepository.GetFlightItems();
        return Ok(_list);
    }


    [HttpGet]
    [Route("items/{id:int}")]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(FlightItem), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<FlightItem>> ItemByIdAsync(int id)
    {
        if (id <= 0)
        {
            return BadRequest();
        }
        var item = await _flightRepository.GetByIdAsync(id);

        if(item == null)
        {
            return NotFound();
        }
        return Ok(item);
    }


    //PUT api/v1/[controller]/items
    [Route("UpdateFlightPrice")]
    [HttpPut]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.Created)]
    public async Task<ActionResult> UpdateFlightPrice([FromBody] FlightItemDto productToUpdate)
    {
        var flightItem = await _flightRepository.GetByIdAsync(productToUpdate.Id);

        if (flightItem == null)
        {
            return NotFound(new { Message = $"Item with id {productToUpdate.Id} not found." });
        }

        flightItem.UpdatePrice(productToUpdate.Price);

        await _flightRepository.UnitOfWork.SaveEntitiesAsync();


        return CreatedAtAction(nameof(ItemByIdAsync), new { id = productToUpdate.Id }, null);
    }


    [Route("UpdateRemain")]
    [HttpPut]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.Created)]
    public async Task<ActionResult> UpdateRemain([FromBody] FlightItemRemain productToUpdate)
    {
        var catalogItem = await _flightRepository.GetByIdAsync(productToUpdate.Id);

        if (catalogItem == null)
        {
            return NotFound(new { Message = $"Item with id {productToUpdate.Id} not found." });
        }

        catalogItem.RemoveFlight(productToUpdate.Quantity);

        await _flightRepository.UnitOfWork.SaveEntitiesAsync();


        return CreatedAtAction(nameof(ItemByIdAsync), new { id = productToUpdate.Id }, null);
    }

}

public class FlightItemDto
{
    public string? Name { get; set; }
    public int Id { get; set; }
    public decimal Price { get; set; }
}
public class FlightItemRemain
{
    public int Id { get; set; }
    public int Quantity { get; set; }
}