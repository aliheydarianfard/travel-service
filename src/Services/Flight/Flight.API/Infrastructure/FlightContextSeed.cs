
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
            await context.handlers.AddRangeAsync(SeddHandler());

            await context.SaveChangesAsync();
        }

        if (!context.flightItems.Any())
        {
            await context.flightItems.AddRangeAsync(SeedFlightItems());

            await context.SaveChangesAsync();

        }

        if (!context.agencies.Any())
        {
            await context.agencies.AddRangeAsync(SeedAgency());

            await context.SaveChangesAsync();

        }
    }

    private IEnumerable<Handler> SeddHandler()
    {
        return new List<Handler>()
        {
            new Handler( "kish air",null),
            new Handler("mahan",null),
            new Handler("homares",null),
            new Handler("kaspian","the cheapest price flight"),
      

        };
    }

    private IEnumerable<FlightItem> SeedFlightItems()
    {
        return new List<FlightItem>()
        {
             new FlightItem(flightNumber: "A129-THR-MHD-MAHAN",price:55M,markup: 0M,discount: 10M,remain: 35,handlerId:1,minimumquantity: 3,source:"THR",destination:"MHD"),
             new FlightItem(flightNumber: "C753-KIH-THR-PARTO",price:35M,markup: 10M,discount: 0M,remain: 55,handlerId:2,minimumquantity: 5,source:"KIHD",destination:"THR"),
        };
    }
    private IEnumerable<Agency> SeedAgency()
    {
        return new List<Agency>()
        {
         new Agency("Vip Agancy",2),
         new Agency("Vip Agancy",3),
         new Agency("charte724 Agancy",1),



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

