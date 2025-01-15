public class Hotel
{
  public int HotelId { get; set; }
  // Properties
  public string? Name { get; set; }
  public List<string> Gallery { get; set; } = [];
  public List<string> Description { get; set; } = [];
  public List<string> SubDescription { get; set; } = [];
  public string? Address { get; set; }
  public int? TotalVote { get; set; }
  
  public double? TotalRating { get; set; }

  // Internal
  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }
  // Relation
  public List<Review> Reviews { get; set; } = new();
  public List<Booking> Bookings { get; set; } = new();
}