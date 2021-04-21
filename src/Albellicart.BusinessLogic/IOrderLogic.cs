using Albellicart.Models;
using System.Collections.Generic;

namespace Albellicart.BusinessLogic
{
    public interface IOrderLogic
    {
        Order AddOrder(Order order);
        Order GetOrder(int id);
        IEnumerable<Order> GetOrders();
    }
}