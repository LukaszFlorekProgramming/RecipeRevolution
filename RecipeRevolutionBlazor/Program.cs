using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using RecipeRevolutionBlazor;
using RecipeRevolutionBlazor.Services.Recipes;
using RecipeRevolutionBlazor.Services.RecipesPagination;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient<IRecipeService, RecipeService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7052/");
});
builder.Services.AddHttpClient<IRecipeServicePagination, RecipeServicePagination>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7052/");
});

await builder.Build().RunAsync();
