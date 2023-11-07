using Microsoft.EntityFrameworkCore;
using RecipeRevolution.Persistance;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<RecipeRevolutionDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("RecipeDatabase"));
});
builder.Services.AddPersistance();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

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