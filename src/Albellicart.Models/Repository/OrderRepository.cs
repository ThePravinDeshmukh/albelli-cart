using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Albellicart.Models.Repository
{
    public class OrderRepository : IOrderRepository
    {

        private static List<Order> Orders = new List<Order>();
        public OrderRepository()
        {
        }

        public IEnumerable<Order> GetOrders()
        {
            return Orders;
        }
        public Order GetOrder(int id)
        {
            return Orders.FirstOrDefault(x => x.Id == id);
        }
        public Order AddOrder(Order order)
        {
            Orders.Add(order);

            return order;
        }
    }
}
