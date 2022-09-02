
namespace travel.Services.FlightAPI.Infrastructure;
public class FlightContextSeed
{
    public async Task MagirateAndSeedAsync(FlightContext context, IWebHostEnvironment env, ILogger<FlightContextSeed> logger)
    {
        await context.Database.MigrateAsync();


        var contentRootPath = env.ContentRootPath;
        var picturePath = env.WebRootPath;

        if (!context.flightTypes.Any())
        {
            await context.flightTypes.AddRangeAsync(SeddFlightType());

            await context.SaveChangesAsync();
        }

        if (!context.flightItems.Any())
        {
            await context.flightItems.AddRangeAsync(SeedFlightItems());

            await context.SaveChangesAsync();

        }
    }

    private IEnumerable<FlightType> SeddFlightType()
    {
        return new List<FlightType>()
        {
            new FlightType( "Charter",""),
            new FlightType("System","the cheapest price flight"),
      

        };
    }

    private IEnumerable<FlightItem> SeedFlightItems()
    {
        return new List<FlightItem>()
        {
             new FlightItem(flightNumber: "A129-THR-MHD-MAHAN",price:55M,markup: 0M,discount: 10M,remain: 35,flightTypeId:1,minimumquantity: 3,source:"THR",destination:"MHD"),
             new FlightItem(flightNumber: "C753-KIH-THR-PARTO",price:35M,markup: 10M,discount: 0M,remain: 55,flightTypeId:2,minimumquantity: 5,source:"KIHD",destination:"THR"),
        };
    }

    private void GetFlighttemPictures(string contentRootPath, string picturePath)
    {
        if (picturePath != null)
        {
            DirectoryInfo directory = new DirectoryInfo(picturePath);
            foreach (FileInfo file in directory.GetFiles())
            {
                file.Delete();
            }

            string zipFileCatalogItemPictures = Path.Combine(contentRootPath, "Setup", "FlightItem.zip");
            ZipFile.ExtractToDirectory(zipFileCatalogItemPictures, picturePath);
        }
    }

}

