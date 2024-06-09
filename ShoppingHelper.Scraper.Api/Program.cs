using Azure.Identity;
using MediatR;
using Microsoft.Extensions.Azure;
using ShoppingHelper.Scraper.Api.Common.Extensions.IServiceCollectionExtensions;
using ShoppingHelper.Scraper.Api.Common.Options;
using ShoppingHelper.Scraper.Api.Features.ScrapeRecipes.HelloFreshRecipes;
using ShoppingHelper.Scraper.Api.Services.HelloFreshAccessTokenService;

var builder = WebApplication.CreateBuilder(args);
builder.AddServiceDefaults();

builder.Services.RegisterCosmosClient(builder.Configuration);
builder.Services.AddOptionsWithValidateOnStart<CosmosOptions>()
    .BindConfiguration(CosmosOptions.Section)
    .ValidateDataAnnotations();

builder.Services.AddAzureClients(clinetBuilder =>
{
    clinetBuilder.UseCredential(new DefaultAzureCredential());
    clinetBuilder.AddBlobServiceClient(builder.Configuration.GetRequiredSection(BlobStorageOptions.Section));
});

builder.Services.AddOptionsWithValidateOnStart<BlobStorageOptions>()
    .BindConfiguration(BlobStorageOptions.Section)
    .ValidateDataAnnotations();

builder.Services.AddTransient<HelloFreshAuthDelegatingHandler>();
builder.Services.AddOptionsWithValidateOnStart<HelloFreshOptions>()
    .BindConfiguration(HelloFreshOptions.Section)
    .ValidateDataAnnotations();

builder.Services.AddScoped<IHelloFreshAccessTokenService, BlobStorageHelloFreshAccessTokenService>();

builder.Services.AddMediatR(o => o.RegisterServicesFromAssemblyContaining<Program>());

builder.Services.AddHttpClient<IRequestHandler<ScrapeHelloFreshRecipesQuery, ScrapeHelloFreshRecipesResult>, ScrapeHelloFreshRecipesHandler>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration.GetRequiredSection(HelloFreshOptions.Section)[nameof(HelloFreshOptions.BaseAddress)]!);
})
.AddHttpMessageHandler<HelloFreshAuthDelegatingHandler>();

var app = builder.Build();

app.MapDefaultEndpoints();

app.MapGroup("/scrape")
    .MapGet("/hellofresh", ([AsParameters] ScrapeHelloFreshRecipesQuery query, IMediator mediatr, CancellationToken cancellationToken) => mediatr.Send(query, cancellationToken));


app.Run();
