using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Albellicart.Models.Repository
{
    public class OrderRepository : IOrderRepository
    {
        public OrderRepository()
        {
        }

        public IEnumerable<Order> GetOrders()
        {
            using (var context = new AlbellicartContext())
            {
                // Note: This sample requires the database to be created before running.
                return context.Order.Include(b => b.OrderLine).ToList();
            }
        }
        public Order GetOrder(int id)
        {
            using (var context = new AlbellicartContext())
            {
                // Note: This sample requires the database to be created before running.
                return context.Order.Include(b => b.OrderLine).FirstOrDefault(x => x.Id == id);
            }
        }
        public Order AddOrder(Order order)
        {
            using (var context = new AlbellicartContext())
            {
                // Note: This sample requires the database to be created before running.
                context.Order.Add(order);
                context.SaveChanges();

                return order;
            }

        }
    }
}
