using API.Application.Query;
using Domain.Aggregates.FlightAggregate;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace API.Application.Commands
{
    public class GetAvailableFlightsQueryHandler : IRequestHandler<GetAvailableFlightsQuery, ICollection<Flight>>
    {
        private readonly IFlightRepository _airportRepository;

        public GetAvailableFlightsQueryHandler(IFlightRepository airportRepository)
        {
            _airportRepository = airportRepository;
        }

        public async Task<ICollection<Flight>> Handle(GetAvailableFlightsQuery request, CancellationToken cancellationToken)
        {
            var flights = await _airportRepository.GetAllAvailableFlightsAsync(request.DestinationAirportCode);
            return flights;
        }
    }
}