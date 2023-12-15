using OpenTelemetry.Trace;
using Serilog;
using UrlScraper;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();

Log.Information("Starting up");

try
{
    await Host.CreateDefaultBuilder(args)
        .UseSerilog((ctx, config) => 
            config.WriteTo.Console())
        .ConfigureServices(services => services
            .AddHostedService<Worker>()
            .AddOpenTelemetry()
            .WithTracing(builder => builder
                .AddHttpClientInstrumentation()
                .AddConsoleExporter()))
        .Build()
        .RunAsync();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Unhandled exception during startup");
}
finally
{
    Log.Information("Shut down complete");
    Log.CloseAndFlush();
}

