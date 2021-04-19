using Albellicart.Models;
using System.Collections.Generic;

namespace Albellicart.BusinessLogic
{
    public interface IOrderLogic
    {
        Order AddOrder(IEnumerable<OrderLine> orderLines);
        Order GetOrder(int id);
        IEnumerable<Order> GetOrders();
    }
}