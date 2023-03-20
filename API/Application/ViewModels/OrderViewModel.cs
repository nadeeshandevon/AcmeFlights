using System;

namespace API.Application.ViewModels
{
    public class OrderViewModel
    {
        public Guid OrderId { get; set; }
        public Guid FlightId { get; set; }
        public Guid FlightRateId { get; set; }
        public int NoOfSeats { get; set; }
        public bool IsConfirmed { get; set; }
        public DateTimeOffset OrderedDateTime { get; set; }
        public DateTimeOffset? ConfirmedDateTime { get; set; }
    }
}