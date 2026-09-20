using AirlineBookingSystem.Bookings.Core.Entities;
using AirlineBookingSystem.Bookings.Core.Repositories;
using AirlineBookingSystem.Bookings.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineBookingSystem.Bookings.Infrastructure.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly BookingDbContext _bookingDbContext;
        public BookingRepository(BookingDbContext bookingDbContext)
        {
            _bookingDbContext = bookingDbContext;
        }
        public async Task AddBookingAsync(Booking booking)
        {
            await _bookingDbContext.Bookings.AddAsync(booking);
            await _bookingDbContext.SaveChangesAsync();
        }

        public async Task<Booking?> GetBookingByIdAsync(Guid id)
        {
            return await _bookingDbContext.Bookings.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
