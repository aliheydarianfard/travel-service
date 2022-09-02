



using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.IO.Compression;
using travel.Services.Flight.Domain.AggregatesModel.HandlerAggregate;

namespace travel.Services.Flight.Infrastructure;

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

        //if (!context.flightItems.Any())
        //{
        //    //await context.flightItems.AddRangeAsync(SeedFlightItems());

        //    await context.SaveChangesAsync();

        //    GetFlighttemPictures(contentRootPath, picturePath);
        //}
    }

    private IEnumerable<Handler> SeedHandler()
    {
        return new List<Handler>()
        {
            new Handler() { Name = "Mahan"},
            new Handler() { Name = "Parto" },
            new Handler() { Name = "Homares" },
            new Handler() { Name = "Kish Air" }
        };
    }

   // private IEnumerable<FlightItem> SeedFlightItems()
   // {
   //     return new List<FlightItem>()
   //     {
   //new FlightItem(){FlightNumber="AB-123",HandlerId=0,Price=12000,Markup=0,Discount=100 },
   //new FlightItem(){FlightNumber="GH-653",HandlerId=1,Price=32000,Markup=0,Discount=200 },
   //     };
   // }

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

