using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RecipeRevolution.Application;
using RecipeRevolution.Application.Interfaces;
using RecipeRevolution.Domain.Entities;
using RecipeRevolution.Domain.Models;
using RecipeRevolution.Persistance;
using RecipeRevolution.Services;
using RecipeRevolution.Validator;
using System.Security.Claims;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication().AddBearerToken(IdentityConstants.BearerScheme);
builder.Services.AddAuthorizationBuilder();

builder.Services.AddDbContext<RecipeRevolutionDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("RecipeDatabase"));
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAnyOrigin", builder =>
    {
        builder.WithOrigins("https://localhost:7251")
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});
builder.Services.AddIdentityCore<User>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<RecipeRevolutionDbContext>()
                .AddApiEndpoints();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.SignIn.RequireConfirmedEmail = false;
});

builder.Services.AddApplication();
builder.Services.AddPersistance();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IRecipeService, RecipeService>();
builder.Services.AddScoped<IRecipesService, RecipesService>();
builder.Services.AddScoped<IImageService, ImageService>();
builder.Services.AddScoped<IValidator<RecipeQuery>, RecipeQueryValidator>();
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var dbContext = services.GetRequiredService<RecipeRevolutionDbContext>();

    var seeder = new RecipeRevolutionSeeder(dbContext);
    seeder.SeedMigration(); 
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowAnyOrigin");


app.UseHttpsRedirection();
app.MapIdentityApi<User>();
app.MapGet("/test", (ClaimsPrincipal user) => $"Hello {user.Identity!.Name}").RequireAuthorization();
app.MapControllers();
app.Run();