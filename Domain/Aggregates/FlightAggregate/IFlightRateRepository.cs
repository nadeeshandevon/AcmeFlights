using System;
using System.Threading.Tasks;

namespace Domain.Aggregates.FlightAggregate
{
    public interface IFlightRateRepository
    {
        Task<FlightRate> GetAsync(Guid flightRateId);
        Task UpdateAvailable(Guid flightRateId, int noOfSeats);
    }
}