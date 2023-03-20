using Domain.Aggregates.OrderAggregate;
using MediatR;
using System;

namespace API.Application.Commands
{
    public class ConfirmOrderCommand : IRequest<Order>
    {
        public Guid OrderId { get; set; }
    }
}