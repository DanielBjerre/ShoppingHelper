using Microsoft.EntityFrameworkCore;
using ShoppingHelper.Recipes.Api.Persistence.Contexts;
using ShoppingHelper.ServiceDefaults.Extensions.IHostApplicationBuilderExtensions;
using ShoppingHelper.ServiceDefaults.Extensions.WebApplicationExtensions;

var builder = WebApplication.CreateSlimBuilder(args);

builder.AddServiceDefaults();

builder.Services.AddDbContext<RecipeContext>(o =>
{
    o.UseSqlServer(builder.Configuration.GetConnectionString(nameof(RecipeContext)), o =>
    {
        o.UseAzureSqlDefaults();
    });
});

var app = builder.Build();

app.MapDefaultEndpoints();

app.Run();


