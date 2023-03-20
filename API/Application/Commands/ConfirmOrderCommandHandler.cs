using Domain.Aggregates.FlightAggregate;
using Domain.Aggregates.OrderAggregate;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace API.Application.Commands
{
    public class ConfirmOrderCommandHandler : IRequestHandler<ConfirmOrderCommand, Order>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IFlightRateRepository _flightRateRepository;

        public ConfirmOrderCommandHandler(IOrderRepository orderRepository,
            IFlightRateRepository flightRateRepository)
        {
            _orderRepository = orderRepository;
            _flightRateRepository = flightRateRepository;
        }

        public async Task<Order> Handle(ConfirmOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetOrderAsync(request.OrderId);
            
            await _orderRepository.ConfirmOrderAsync(request.OrderId);
            await _flightRateRepository.UpdateAvailable(order.FlightRateId, order.NoOfSeats);
            await _orderRepository.UnitOfWork.SaveEntitiesAsync();
            
            return order;
        }
    }
}