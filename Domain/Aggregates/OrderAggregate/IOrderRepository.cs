using Domain.SeedWork;
using System;
using System.Threading.Tasks;

namespace Domain.Aggregates.OrderAggregate
{
    public interface IOrderRepository: IRepository<Order>
    {
        Task<Order> GetOrderAsync(Guid orderId);
        Order Add(Order order);
        Task ConfirmOrderAsync(Guid orderId);
    }
}