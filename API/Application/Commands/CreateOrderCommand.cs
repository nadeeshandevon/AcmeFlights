using Domain.Aggregates.OrderAggregate;
using MediatR;
using System;

namespace API.Application.Commands
{
    public class CreateOrderCommand : IRequest<Order>
    {
        public int NoOfSeats { get; set; }
        public Guid FlightRateId { get; set; }
    }
}