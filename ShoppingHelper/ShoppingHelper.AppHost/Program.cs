var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.ShoppingHelper_Recipes_Api>("shoppinghelper-recipes-api");

builder.AddProject<Projects.ShoppingHelper_Scraper_Api>("shoppinghelper-scraper-api");

builder.AddProject<Projects.ShoppingHelper_Scraper_RecipeScrapedProcessor>("shoppinghelper-scraper-recipescrapedprocessor");

builder.AddProject<Projects.ShoppingHelper_Recipes_AddScrapedRecipeProcessor>("shoppinghelper-recipes-addscrapedrecipeprocessor");

builder.AddProject<Projects.ShoppingHelper_Scraper_Processor_ScrapeRequested>("shoppinghelper-scraper-processor-scraperequested");

builder.AddProject<Projects.ShoppingHelper_AsyncMessaging_Api>("shoppinghelper-asyncmessaging-api");

builder.Build().Run();
