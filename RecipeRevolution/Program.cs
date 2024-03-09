using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using RecipeRevolution.Application;
using RecipeRevolution.Application.Interfaces;
using RecipeRevolution.Domain.Entities;
using RecipeRevolution.Domain.Models;
using RecipeRevolution.Infrastructure;
using RecipeRevolution.Persistance;
using RecipeRevolution.Services;
using RecipeRevolution.Services.Blob;
using RecipeRevolution.Services.Comment;
using RecipeRevolution.Services.Email;
using RecipeRevolution.Services.Recipe;
using RecipeRevolution.Services.User;
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
        builder.WithOrigins("https://localhost:7251", "https://localhost:7239", "https://reciperevolutionui.azurewebsites.net")
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
    options.SignIn.RequireConfirmedEmail = true;
});

builder.Services.AddApplication();
builder.Services.AddPersistance();
builder.Services.AddInfrastructure();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Recipe Revolution",
        Version = "v1",
        Description = "This is an application for information exchange in our RecipeRevolution project.",
        Contact = new OpenApiContact
        {
            Name = "£ukasz ",
            Email = "lukaszflorek2@gmail.com",
            Url = new Uri("https://github.com/LukaszFlorekProgramming/RecipeRevolution")
        }
    });
});
builder.Services.AddScoped<IRecipeService, RecipeService>();
builder.Services.AddScoped<IRecipesService, RecipesService>();
builder.Services.AddScoped<IImageService, ImageService>();
builder.Services.AddScoped<IUserService,UserService>();
builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<IValidator<RecipeQuery>, RecipeQueryValidator>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSingleton<IBlobService, BlobService>();
builder.Services.Configure<AuthMessageSenderOptions>(builder.Configuration.GetSection("AuthMessageSenderOptions"));
builder.Services.AddTransient<IEmailSender, EmailSender>();


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var dbContext = services.GetRequiredService<RecipeRevolutionDbContext>();

    var seeder = new RecipeRevolutionSeeder(dbContext);
    seeder.SeedMigration(); 
}

/*if (app.Environment.IsDevelopment())
{*/
    app.UseSwagger();
    app.UseSwaggerUI();
//}
app.UseCors("AllowAnyOrigin");

// test 2

app.UseHttpsRedirection();
app.MapIdentityApi<User>();
app.MapGet("/test", (ClaimsPrincipal user) => $"Hello {user.Identity!.Name}").RequireAuthorization();
app.MapControllers();
app.Run();