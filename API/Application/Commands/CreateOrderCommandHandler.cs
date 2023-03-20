using Domain.Aggregates.FlightAggregate;
using Domain.Aggregates.OrderAggregate;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace API.Application.Commands
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Order>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IFlightRateRepository _flightRateRepository;

        public CreateOrderCommandHandler(IOrderRepository orderRepository,
            IFlightRateRepository flightRateRepository)
        {
            _orderRepository = orderRepository;
            _flightRateRepository = flightRateRepository;
        }

        public async Task<Order> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var fligtRate = await _flightRateRepository.GetAsync(request.FlightRateId);
            var order = new Order
            {
                FlightId = fligtRate.FlightId,
                FlightRateId = request.FlightRateId,
                IsConfirmed = false,
                NoOfSeats = request.NoOfSeats,
                OrderedDateTime = DateTime.UtcNow
            };

            var orderResult = _orderRepository.Add(order);
            await _orderRepository.UnitOfWork.SaveEntitiesAsync();
            
            return orderResult;
        }
    }
}