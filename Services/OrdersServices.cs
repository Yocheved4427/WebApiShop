using Repositories;
using Entities;
namespace Services
{
    public class OrdersServices : IOrdersServices
    {
        public readonly IOrdersRepository _orders;
        public OrdersServices(IOrdersRepository orders)
        {
            _orders = orders;
        }

        public async Task<Order?> GetOrderById(int id)
        {
            return await _orders.GetOrderById(id);
        }
        public async Task<Order> AddOrder(Order order)
        {
            return await _orders.AddOrder(order);
        }
    }
}
