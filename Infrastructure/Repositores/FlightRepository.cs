using Domain.Aggregates.FlightAggregate;
using Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositores
{
    public class FlightRepository : IFlightRepository
    {
        private readonly FlightsContext _context;

        public IUnitOfWork UnitOfWork
        {
            get { return _context; }
        }

        public FlightRepository(FlightsContext context)
        {
            _context = context;
        }

        public Flight Add(Flight flight)
        {
            return _context.Flights.Add(flight).Entity;
        }

        public void Update(Flight flight)
        {
            _context.Flights.Update(flight);
        }

        public async Task<Flight> GetAsync(Guid flightId)
        {
            return await _context.Flights.FirstOrDefaultAsync(o => o.Id == flightId);
        }

        public async Task<ICollection<Flight>> GetAllAvailableFlightsAsync(string destinationCode)
        {    
            var query = await _context.Flights
                .Include(t => t.Rates)
                .Include(t => t.DestinationAirport)
                .Include(t => t.OriginAirport)
                .Where(t => t.DestinationAirport.Code.ToLower().Contains(destinationCode.ToLower().Trim()) &&
                t.Rates.Any(a => a.Available > 0))
                .ToListAsync();

            return query.ToList();
        }
    }
}