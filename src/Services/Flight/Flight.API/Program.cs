

var configuration = GetConfiguration();

try
{
    var host = CreateHostBuilder(configuration, args);
    Log.Information("Configuring web host ({ApplicationContext})...", Program.AppName);
    Log.Information("Applying migrations ({ApplicationContext})...", Program.AppName);
    using (var scope = host.Services.CreateScope())
    {
        var context = scope.ServiceProvider.GetService<FlightContext>();
        var env = scope.ServiceProvider.GetService<IWebHostEnvironment>();
        var logger = scope.ServiceProvider.GetRequiredService<ILogger<FlightContextSeed>>();
        var delay = Backoff.DecorrelatedJitterBackoffV2(medianFirstRetryDelay: TimeSpan.FromSeconds(1), 5);
        var retry = Policy.Handle<Exception>().WaitAndRetry(delay);
                         
        retry.Execute(() =>
        {
            new FlightContextSeed().MagirateAndSeedAsync(context, env, logger).Wait();
        });


    }


    Log.Information("Starting web host ({ApplicationContext})...", Program.AppName);
    host.Run();

}
catch (Exception ex)
{
    Log.Fatal(ex, "Host terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}

IConfiguration GetConfiguration()
{
    var path = Directory.GetCurrentDirectory();

    var builder = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        .AddEnvironmentVariables();

    return builder.Build();
}


IHost CreateHostBuilder(IConfiguration configuration, string[] args) =>

Host.CreateDefaultBuilder(args)
   .ConfigureWebHostDefaults(webBuilder =>
   {
       webBuilder.UseStartup<Startup>()
      .UseContentRoot(Directory.GetCurrentDirectory())
      .UseWebRoot("Pics")
      .ConfigureAppConfiguration(x => x.AddConfiguration(configuration))
      .CaptureStartupErrors(false);
   })
   .UseSerilog(SeriLogger.Configure)
   .Build();



public partial class Program
{

    public static string? Namespace = typeof(Startup).Namespace;
    public static string? AppName = "Catalog.API";
}
