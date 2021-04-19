using System.Collections.Generic;

namespace Albellicart.Models.Repository
{
    public interface IOrderRepository
    {
        Order AddOrder(Order order);
        Order GetOrder(int id);
        IEnumerable<Order> GetOrders();
    }
}