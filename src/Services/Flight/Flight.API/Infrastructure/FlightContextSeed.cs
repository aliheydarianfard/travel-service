
namespace travel.Services.FlightAPI.Infrastructure;
public class FlightContextSeed
{
    public async Task MagirateAndSeedAsync(FlightContext context, IWebHostEnvironment env, ILogger<FlightContextSeed> logger)
    {
        await context.Database.MigrateAsync();


        var contentRootPath = env.ContentRootPath;
        var picturePath = env.WebRootPath;

        if (!context.handlers.Any())
        {
            await context.handlers.AddRangeAsync(SeedHandler());

            await context.SaveChangesAsync();
        }

        if (!context.flightItems.Any())
        {
            await context.flightItems.AddRangeAsync(SeedFlightItems());

            await context.SaveChangesAsync();

        }
    }

    private IEnumerable<Handler> SeedHandler()
    {
        return new List<Handler>()
        {
            new Handler( "Mahan","the best iranian handler"),
            new Handler("Parto", "the cheapest iranian handler"),
            new Handler("Homares", ""),
            new Handler("Kish Air", ""),

        };
    }

    private IEnumerable<FlightItem> SeedFlightItems()
    {
        return new List<FlightItem>()
        {
   new FlightItem(flightNumber: "A12-THR-MHD-MAHAN",price:55M,markup: 0M,discount: 10M,remain: 35,handlerId:1,stockThreshold: 3),
   new FlightItem(flightNumber: "C132-KIH-THR-PARTO",price:35M,markup: 10M,discount: 0M,remain: 55,handlerId:2,stockThreshold: 5),
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

