using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace TrilloBackend.Controllers
{

    [Route("api/hotels")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private readonly TrilloContext _context;

        public HotelsController(TrilloContext context)
        {
            _context = context;
        }

// ***********************************************************************************
// ********GET********
        // GET: api/hotels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hotel>>> GetHotels()
        {
            return await _context.Hotels
                .Include(e => e.Reviews)
                .Include(e => e.Bookings)
                .ToListAsync();
        }

        [HttpGet("Booking")]
        public async Task<ActionResult<IEnumerable<Booking>>> GetBookings()
        {
            return await _context.Bookings
                .Include(e => e.Order)
                .Include(e => e.Hotel)
                .ToListAsync();
        }

        // GET: api/hotels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Hotel>> GetHotel(long id)
        {
            var hotel = await _context.Hotels
                .Include(e => e.Reviews)
                .Include(e => e.Bookings)
                .FirstOrDefaultAsync(e => e.HotelId == id)
               ;

            if (hotel == null)
            {
                return NotFound();
            }

            return hotel;
        }

        // GET: api/hotels/5/booking
        [HttpGet("{id}/bookings")]
        public async Task<ActionResult<IEnumerable<Booking>>> GetHotelBooking(int id, DateTime?startdate, DateTime?enddate)
        {
            if (startdate == null || enddate == null ) {
                return BadRequest("Hotel at least one date must be provided.");
            }

            var hotelbooking = await _context.Bookings
                .Where(e => e.HotelId == id && e.Date >= startdate && e.Date < enddate)
                .ToListAsync();

            if (hotelbooking == null)
            {
                return NotFound();
            }

            return Ok(hotelbooking);
        }

        // GET: api/hotels/search
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Hotel>>> GetHotelSearch(string? name, string? address)
        {
            // check Name and Address record
            var hotelQuery = _context.Hotels
                .Include(e => e.Reviews)
                .Include(e => e.Bookings)
                .AsQueryable();

            // name && address
            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(address))
            {   
                var result = await hotelQuery
                    .Where(e => EF.Functions.Like(e.Name, $"%{name}%") && EF.Functions.Like(e.Address, $"%{address}%"))
                    .ToListAsync();
                return result;
            }

            // check name without address
            if (!string.IsNullOrEmpty(name))
            {
                var result = await hotelQuery
                    .Where(e => EF.Functions.Like(e.Name, $"%{name}%"))
                    .ToListAsync();
                if (result.Any())
                    return result;
            }

            // chenck address without name
            if (!string.IsNullOrEmpty(address))
            {
                var result = await hotelQuery
                    .Where(e => EF.Functions.Like(e.Address, $"%{address}%"))
                    .ToListAsync();
                if (result.Any())
                    return result;
            }

            // return []
            return new List<Hotel>();
        }

// ***********************************************************************************
// ********PUT********
        // PUT: api/hotels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHotel(int id, Hotel hotel)
        {
            if (id != hotel.HotelId)
            {
                return BadRequest();
            }

            _context.Entry(hotel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HotelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

// ***********************************************************************************
// ********POST********
        // POST: api/hotels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Hotel>> PostHotel(Hotel hotel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Check for duplicate hotel
            if (_context.Hotels.Any(h => h.Name == hotel.Name && h.Address == hotel.Address))
            {
                return Conflict("A hotel with the same name and address already exists.");
            }

            try
            {
                _context.Hotels.Add(hotel);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetHotel), new { id = hotel.HotelId }, hotel);
            }
            catch (DbUpdateException ex)
            {
                var detailedError = ex.InnerException?.Message ?? ex.Message;
                return StatusCode(500, $"An error occurred while saving the hotel: {detailedError}");
            }
        }


         // POST: api/hotels/5/booking
        [HttpPost("{id}/booking")]
        public async Task<ActionResult<Booking>> PostHotelBooking(int id, Booking booking)
        {
            if (!_context.Bookings.Any(h => h.HotelId == booking.HotelId))
            {
                return Conflict("A booking must related with a hotel");
            }

            if (BookingExists(id)) 
            {
                if (id != booking.BookingId)
                {
                    return BadRequest();
                }
                _context.Entry(booking).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return NoContent();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                try
                {
                    _context.Bookings.Add(booking);
                    await _context.SaveChangesAsync();
                    return CreatedAtAction(nameof(GetBookings), new { id = booking.BookingId }, booking);
                }
                catch (DbUpdateException ex)
                {
                    var detailedError = ex.InnerException?.Message ?? ex.Message;
                    return StatusCode(500, $"An error occurred while saving the hotel: {detailedError}");
                }
            }
        }

// ***********************************************************************************
// ********DELETE********
        // DELETE: api/hotels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotel(int id)
        {
            var hotel = await _context.Hotels.FindAsync(id);
            if (hotel == null)
            {
                return NotFound();
            }

            _context.Hotels.Remove(hotel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HotelExists(int id)
        {
            return _context.Hotels.Any(e => e.HotelId == id);
        }

        private bool BookingExists(int id)
        {
            return _context.Bookings.Any(e => e.BookingId == id);
        }
    }
}
