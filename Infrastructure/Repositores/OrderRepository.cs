using Domain.Aggregates.OrderAggregate;
using Domain.Exceptions;
using Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Infrastructure.Repositores
{
    public class OrderRepository : IOrderRepository
    {
        private readonly FlightsContext _context;

        public IUnitOfWork UnitOfWork
        {
            get { return _context; }
        }

        public OrderRepository(FlightsContext context)
        {
            _context = context;
        }

        public async Task<Order> GetOrderAsync(Guid orderId)
        {
            return await _context.Orders.FirstOrDefaultAsync(o => o.Id == orderId);
        }

        public Order Add(Order order)
        {
            return _context.Orders.Add(order).Entity;
        }

        public async Task ConfirmOrderAsync(Guid orderId)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(o => o.Id == orderId);

            if (order == null)
            {
                throw new OrderDomainException($"Order does not exist for this order id : {orderId}");
            }

            if (order.IsConfirmed)
            {
                throw new OrderDomainException($"This order already confirmed, order id : {orderId}");
            }

            order.IsConfirmed = true;
            order.ConfirmedDateTime = DateTime.UtcNow;

            _context.Orders.Update(order);
        }
    }
}