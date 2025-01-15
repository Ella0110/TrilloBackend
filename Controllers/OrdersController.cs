using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace TrilloBackend.Controllers
{

    [Route("api/orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly TrilloContext _context;

        public OrdersController(TrilloContext context)
        {
            _context = context;
        }

        // Get: api/orders
        [HttpGet("id")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            return order;
        }

        // POST: api/orders
        [HttpPost("booking")]
        public async Task<ActionResult<IEnumerable<Order>>> PostGetOrder(string? hotelname, [FromQuery] string[] dates)
        {
            // Check if hotelname or date are null or empty
            if (string.IsNullOrEmpty(hotelname) || dates == null || dates.Length == 0)
    {
                return BadRequest("Hotel name and at least one date must be provided.");
    }

            // Parse the date from string
            var parsedDates = new List<DateTime>();
            foreach (var date in dates)
            {
                if (DateTime.TryParse(date, out DateTime parsedDate))
                {
                    parsedDates.Add(parsedDate);
                }
                else
                {
                    return BadRequest($"Invalid date format: {date}");
                }
            }

            // Find the hotel by name
            var hotel = await _context.Hotels.FirstOrDefaultAsync(h => h.Name == hotelname);
            if (hotel == null)
            {
                return NotFound($"Hotel '{hotelname}' not found.");
            }

            // Query the booking table to find matching records
            var bookings = await _context.Bookings
                .Where(b => b.HotelId == hotel.HotelId && parsedDates.Contains(b.Date.Value) && (b.isAvailable ?? false))
                .ToListAsync();

            // If no available bookings are found, return an exception
            if (bookings == null || bookings.Count == 0)
            {
                return NotFound($"No available bookings found for hotel '{hotelname}' on {parsedDates}.");
            }

            // Create a new Order
            var totalAmount = bookings.Sum(b => b.Price); // Sum the prices from the bookings
            var newOrder = new Order
            {
                UserId = 1111,  // This should be set according to your logic
                GuestName = "someGuestName", // This should be set according to your logic
                Amount = totalAmount,
                // DateCreated = DateTime.Now
            };

            _context.Orders.Add(newOrder);
            await _context.SaveChangesAsync();

            // Update the bookings with the new OrderId and set IsAvailable to false
            foreach (var booking in bookings)
            {
                booking.OrderId = newOrder.OrderId;
                booking.isAvailable = false;
            }

            // Save the updated bookings
            await _context.SaveChangesAsync();

            // Return the created Order
            return CreatedAtAction(nameof(GetOrder), new { id = newOrder.OrderId }, newOrder);
        }


        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.OrderId == id);
        }
    }
}
