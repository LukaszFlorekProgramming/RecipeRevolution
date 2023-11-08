using Microsoft.EntityFrameworkCore;
using RecipeRevolution.Application;
using RecipeRevolution.Application.Interfaces;
using RecipeRevolution.Persistance;
using RecipeRevolution.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<RecipeRevolutionDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("RecipeDatabase"));
});
builder.Services.AddApplication();
builder.Services.AddPersistance();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddScoped<IRecipeService, RecipeService>();   

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();