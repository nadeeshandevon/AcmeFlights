using Domain.Aggregates.FlightAggregate;
using MediatR;
using System.Collections.Generic;

namespace API.Application.Query
{
    public class GetAvailableFlightsQuery : IRequest<ICollection<Flight>>
    {
        public string DestinationAirportCode { get; set; }
    }
}