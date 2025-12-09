using Entities;

namespace Services
{
    public interface IOrdersServices
    {
        Task<Order?> GetOrderById(int id);
        Task<Order> AddOrder(Order order);
    }
}