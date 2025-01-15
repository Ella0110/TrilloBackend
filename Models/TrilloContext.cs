using Microsoft.EntityFrameworkCore;

public class TrilloContext : DbContext
{
  public DbSet<Hotel> Hotels { get; set; }
  public DbSet<Review> Reviews { get; set; }
  public DbSet<Order> Orders { get; set; }
  public DbSet<Booking> Bookings { get; set; }

  protected override void OnConfiguring(DbContextOptionsBuilder options)
  {
    var builder = WebApplication.CreateBuilder();
    var configuration = new ConfigurationBuilder()
      .AddJsonFile("appsettings.json")
      // Load configuration for current environment.
      .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true)
      .AddEnvironmentVariables()
      .Build();
    // log to console
    // options.EnableSensitiveDataLogging(true);
    // options.LogTo(Console.WriteLine);
    // Connect to the database.
    options.UseNpgsql(configuration.GetConnectionString("TrilloDatabase"));

  }

  // Generate Date/time.
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<Booking>(e => {
      e.Property(b => b.CreatedAt).HasDefaultValueSql("now()");
      e.Property(b => b.UpdatedAt).HasDefaultValueSql("now()");
    });

    modelBuilder.Entity<Hotel>(e => {
      e.Property(b => b.CreatedAt).HasDefaultValueSql("now()");
      e.Property(b => b.UpdatedAt).HasDefaultValueSql("now()");
    });

    modelBuilder.Entity<Order>(e => {
      e.Property(b => b.CreatedAt).HasDefaultValueSql("now()");
      e.Property(b => b.UpdatedAt).HasDefaultValueSql("now()");
    });

    modelBuilder.Entity<Review>(e => {
      e.Property(b => b.CreatedAt).HasDefaultValueSql("now()");
      e.Property(b => b.UpdatedAt).HasDefaultValueSql("now()");
    });
  }
}







