using MediatR;
using ShoppingHelper.Scraper.Api.Common.Extensions.IServiceCollectionExtensions;
using ShoppingHelper.Scraper.Api.Common.Options;
using ShoppingHelper.Scraper.Api.Features.Recipes.GetRecipe;
using ShoppingHelper.Scraper.Api.Features.Scrape.Request;
using ShoppingHelper.Scraper.RecipeScrapedProcessor.Common.Extensions.IServiceCollectionExtensions;
using ShoppingHelper.ServiceDefaults.Extensions.IHostApplicationBuilderExtensions;
using ShoppingHelper.ServiceDefaults.Extensions.WebApplicationExtensions;

var builder = WebApplication.CreateBuilder(args);
builder.AddServiceDefaults();

builder.Services.RegisterCosmosClient(builder.Configuration);
builder.Services.AddOptionsWithValidateOnStart<CosmosOptions>()
    .BindConfiguration(CosmosOptions.Section)
    .ValidateDataAnnotations();

builder.Services.RegisterMassTransit(builder.Configuration);


builder.Services.AddMediatR(o => o.RegisterServicesFromAssemblyContaining<Program>());

var app = builder.Build();

app.MapDefaultEndpoints();

app.MapGroup("/scrape")
    .MapGet("/request", ([AsParameters] ScrapeRequestCommand command, IMediator mediatr, CancellationToken cancellationToken) => mediatr.Send(command, cancellationToken));

app.MapGet("/recipes", ([AsParameters] GetRecipeQuery query, IMediator mediatr, CancellationToken cancellationToken) => mediatr.Send(query, cancellationToken));

app.Run();
