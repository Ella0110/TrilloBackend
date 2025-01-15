using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Fixing the error “A possible object cycle was detected”.
builder.Services.AddControllers().AddJsonOptions(x =>
    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddDbContext<TrilloContext>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", policy =>
    {
        policy.WithOrigins("http://localhost:3000",
                            "https://ella0110.github.io") 
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
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

app.UseCors("AllowSpecificOrigin");
app.UseHttpsRedirection();
app.MapControllers();
app.Run();
