using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using RecipeRevolutionBlazor;
using RecipeRevolutionBlazor.Services.Recipes;
using RecipeRevolutionBlazor.Services.RecipesPagination;
using RecipeRevolutionBlazor.Services.Users;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

void ConfigureHttpClient(HttpClient client)
{
    client.BaseAddress = new Uri("https://localhost:7052/");
}
builder.Services.AddHttpClient<IRecipeService, RecipeService>(ConfigureHttpClient);
builder.Services.AddHttpClient<IRecipeServicePagination, RecipeServicePagination>(ConfigureHttpClient);
builder.Services.AddHttpClient<IUserService, UserService>(ConfigureHttpClient);

await builder.Build().RunAsync();
