using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using RecipeRevolutionBlazorApp;
using RecipeRevolutionBlazorApp.Services.Comments;
using RecipeRevolutionBlazorApp.Services.Images;
using RecipeRevolutionBlazorApp.Services.Recipes;
using RecipeRevolutionBlazorApp.Services.Token;
using RecipeRevolutionBlazorApp.Services.Users;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddTransient<AuthTokenHandler>();
builder.Services.AddScoped<AuthTokenService>();

builder.Services.AddHttpClient("AuthorizedClient", client =>
{
#if DEBUG
    client.BaseAddress = new Uri("https://localhost:7052/");
#else
client.BaseAddress = new Uri("https://reciperevolution.azurewebsites.net/");
#endif
    //client.BaseAddress = new Uri("https://localhost:7052/");
}).AddHttpMessageHandler<AuthTokenHandler>();

builder.Services.AddScoped<IUserService, UserService>(sp =>
{
    var httpClientFactory = sp.GetRequiredService<IHttpClientFactory>();
    var httpClient = httpClientFactory.CreateClient("AuthorizedClient");
    var authTokenService = sp.GetRequiredService<AuthTokenService>();
    return new UserService(httpClient, authTokenService);
});
builder.Services.AddScoped<IRecipeService, RecipeService>(sp =>
{
    var httpClientFactory = sp.GetRequiredService<IHttpClientFactory>();
    var httpClient = httpClientFactory.CreateClient("AuthorizedClient");
    var authTokenService = sp.GetRequiredService<AuthTokenService>();
    return new RecipeService(httpClient, authTokenService);
});
builder.Services.AddScoped<ICommentService, CommentService>(sp =>
{
    var httpClientFactory = sp.GetRequiredService<IHttpClientFactory>();
    var httpClient = httpClientFactory.CreateClient("AuthorizedClient");
    var authTokenService = sp.GetRequiredService<AuthTokenService>();
    return new CommentService(httpClient, authTokenService);
});
builder.Services.AddScoped<IImageService, ImageService>(sp =>
{
    var httpClientFactory = sp.GetRequiredService<IHttpClientFactory>();
    var httpClient = httpClientFactory.CreateClient("AuthorizedClient");
    var authTokenService = sp.GetRequiredService<AuthTokenService>();
    return new ImageService(httpClient, authTokenService);
});

await builder.Build().RunAsync();
