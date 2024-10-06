using ShoppingHelper.Scraper.Processor.ScrapeRequested.Common.Extensions.IServiceCollectionExtensions;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.RegisterCosmos(builder.Configuration);
builder.Services.RegisterMassTransit(builder.Configuration);
builder.Services.RegisterHelloFreshServices(builder.Configuration);

var host = builder.Build();
host.Run();
