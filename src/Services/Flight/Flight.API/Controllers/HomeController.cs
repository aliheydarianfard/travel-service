
namespace travel.Services.Flight.FlightAPI.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return new RedirectResult("~/swagger");
    }
}

