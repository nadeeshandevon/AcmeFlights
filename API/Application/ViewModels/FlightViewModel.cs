using System;

namespace API.Application.ViewModels
{
    public class FlightViewModel
    {
        public string DepartureAirportCode { get; set; }
        public string ArrivalAirportCode { get; set; }
        public DateTimeOffset Departure { get; set; }
        public DateTimeOffset Arrival { get; set; }
        public decimal PriceFrom { get; set; }
        public Guid FlightRateId { get; set; }
    }
}