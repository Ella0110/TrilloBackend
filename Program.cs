using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDbContext<TrilloContext>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Prepare database.
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<TrilloContext>();
    if (app.Environment.IsDevelopment())
    {
        Console.WriteLine($"DbConnectionString: {context.Database.GetConnectionString()}");
    }
    // Create Database and apply migrations.
    context.Database.Migrate();
    // Seed data to tables.
    DbInitializer.Initialize(context);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Test api.
app.MapGet("/Ping", () =>
{
    return "Pong";
})
.WithName("Ping")
.WithOpenApi();

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
