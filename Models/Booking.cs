public class Booking
{
  public int BookingId { get; set; }
  // FK
  public int? HotelId { get; set; }
  public int? OrderId { get; set; }
  // Properties
  public DateTime? Date { get; set; }
  public double? Price { get; set; }
  public bool? isAvailable { get; set; }
  // Internal
  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }
  // Relation
  public Order Order { get; set; } = new();
  public Hotel Hotel { get; set; } = new();
}
