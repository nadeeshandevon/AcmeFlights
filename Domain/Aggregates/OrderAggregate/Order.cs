using Domain.Aggregates.FlightAggregate;
using Domain.SeedWork;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Aggregates.OrderAggregate
{
    public class Order : Entity, IAggregateRoot
    {
        [ForeignKey("Flight")]
        public Guid FlightId { get; set; }

        [ForeignKey("FlightRate")]
        public Guid FlightRateId { get; set; }

        public int NoOfSeats { get; set; }
        public bool IsConfirmed { get; set; }
        public DateTimeOffset OrderedDateTime { get; set; }
        public DateTimeOffset? ConfirmedDateTime { get; set; }

        public Flight Flight { get; set; }
        public FlightRate FlightRate { get; set; }
    }
}