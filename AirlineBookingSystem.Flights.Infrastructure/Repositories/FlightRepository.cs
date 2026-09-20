using AirlineBookingSystem.Flights.Core.Entities;
using AirlineBookingSystem.Flights.Core.Repositories;
using AirlineBookingSystem.Flights.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineBookingSystem.Flights.Infrastructure.Repositories
{
    public class FlightRepository : IFlightRepository
    {
        private readonly FlightDbContext _flightDbContext;
        public FlightRepository(FlightDbContext flightDbContext)
        {
            _flightDbContext = flightDbContext;
        }
        public async Task AddFlightAsync(Flight flight)
        {
            await _flightDbContext.Flights.AddAsync(flight);
            await _flightDbContext.SaveChangesAsync();
        }

        public async Task DeleteFlightAsync(Guid id)
        {
            var flight = await _flightDbContext.Flights.FirstOrDefaultAsync(x => x.Id == id);
            if (flight != null)
            {
                _flightDbContext.Flights.Remove(flight);
                await _flightDbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Flight>> GetFlightsAsync()
        {
            return await _flightDbContext.Flights.ToListAsync();
        }
    }
}
