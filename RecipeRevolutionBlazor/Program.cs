using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using RecipeRevolutionBlazor;
using RecipeRevolutionBlazor.Services.Images;
using RecipeRevolutionBlazor.Services.Recipes;
using RecipeRevolutionBlazor.Services.RecipesPagination;
using RecipeRevolutionBlazor.Services.Users;
using System.Net.Http.Headers;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7052/") });

builder.Services.AddSingleton<AuthTokenService>();

builder.Services.AddScoped<IRecipeService, RecipeService>(sp =>
{
    var httpClient = sp.GetRequiredService<HttpClient>();
    var authTokenService = sp.GetRequiredService<AuthTokenService>();
    ConfigureHttpClient(httpClient, authTokenService);
    return new RecipeService(httpClient, authTokenService);
});

builder.Services.AddScoped<IRecipeServicePagination, RecipeServicePagination>(sp =>
{
    var httpClient = sp.GetRequiredService<HttpClient>();
    var authTokenService = sp.GetRequiredService<AuthTokenService>();
    ConfigureHttpClient(httpClient, authTokenService);
    return new RecipeServicePagination(httpClient);
});

builder.Services.AddScoped<IUserService, UserService>(sp =>
{
    var httpClient = sp.GetRequiredService<HttpClient>();
    var authTokenService = sp.GetRequiredService<AuthTokenService>();
    ConfigureHttpClient(httpClient, authTokenService);
    return new UserService(httpClient);
});
builder.Services.AddScoped<IImageService, ImageService>(sp =>
{
    var httpClient = sp.GetRequiredService<HttpClient>();
    var authTokenService = sp.GetRequiredService<AuthTokenService>();
    ConfigureHttpClient(httpClient, authTokenService);
    return new ImageService(httpClient, authTokenService);
});


await builder.Build().RunAsync();

void ConfigureHttpClient(HttpClient client, AuthTokenService authTokenService)
{
    var authToken = authTokenService.Token;

    if (!string.IsNullOrEmpty(authToken))
    {
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authToken);
    }
    else
    {
        Console.WriteLine("Brak dostêpnego tokenu.");
    }
}
