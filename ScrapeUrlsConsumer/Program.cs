using MassTransit;
using OpenTelemetry.Trace;
using ScrapeService.Shared.Options;
using Serilog;
using Shared.Extensions.IServiceCollectionExtensions;

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
            .AddMassTransit(x =>
            {
                x.AddConsumersFromNamespaceContaining<Program>();
                x.UsingAzureServiceBus((context, cfg) =>
                {
                    cfg.Host("your connection string");
                    cfg.ConfigureEndpoints(context);
                });
            })
            .RegisterValidatedOptions<SeleniumOptions>(SeleniumOptions.Section)
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

