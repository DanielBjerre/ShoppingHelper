var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.ShoppingHelper_Recipes_Api>("shoppinghelper-recipes-api");

builder.AddProject<Projects.ShoppingHelper_Scraper_Api>("shoppinghelper-scraper-api");

builder.AddProject<Projects.ShoppingHelper_Scraper_RecipeScrapedProcessor>("shoppinghelper-scraper-recipescrapedprocessor");

builder.Build().Run();
