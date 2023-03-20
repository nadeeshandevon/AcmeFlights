using Domain.Aggregates.FlightAggregate;
using Domain.Exceptions;
using Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositores
{
    public class FlightRateRepository : IFlightRateRepository
    {
        private readonly FlightsContext _context;

        public IUnitOfWork UnitOfWork
        {
            get { return _context; }
        }

        public FlightRateRepository(FlightsContext context)
        {
            _context = context;
        }

        public async Task<FlightRate> GetAsync(Guid flightRateId)
        {
            return await _context.FlightRates.FirstOrDefaultAsync(o => o.Id == flightRateId);
        }

        public async Task UpdateAvailable(Guid flightRateId, int noOfSeats)
        {
            var flightRate = _context.FlightRates.FirstOrDefault(o => o.Id == flightRateId);
            if (flightRate == null)
            {
                throw new OrderDomainException($"Flight rate id {flightRateId} not found");
            }

            if (flightRate.Available < noOfSeats)
            {
                throw new OrderDomainException($"Cannot order greater than avaiable seats {flightRate.Available}");
            }

            flightRate.Available -= noOfSeats;
            _context.FlightRates.Update(flightRate);
        }
    }
}