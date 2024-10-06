using ShoppingHelper.Scraper.RecipeScrapedProcessor;
using ShoppingHelper.Scraper.RecipeScrapedProcessor.Common.Extensions.IServiceCollectionExtensions;
using ShoppingHelper.ServiceDefaults.Extensions.IHostApplicationBuilderExtensions;

var builder = Host.CreateApplicationBuilder(args);

builder.AddServiceDefaults();

builder.Services.RegisterCosmosClient(builder.Configuration);
builder.Services.RegisterMassTransit(builder.Configuration);
builder.Services.RegisterOptions();

builder.Services.AddHostedService<Worker>();

var host = builder.Build();
host.Run();
