using Albellicart.Models;
using Albellicart.Models.Repository;
using System;
using System.Collections.Generic;

namespace Albellicart.BusinessLogic
{
    public class OrderLogic : IOrderLogic
    {
        private readonly IOrderRepository _orderRepository;
        public OrderLogic(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public IEnumerable<Order> GetOrders()
        {
            return _orderRepository.GetOrders();
        }
        public Order GetOrder(int id)
        {
            return _orderRepository.GetOrder(id);
        }
        public Order AddOrder(IEnumerable<OrderLine> orderLines)
        {
            Order order = new Order
            {
                OrderLine = orderLines
            };

            return _orderRepository.AddOrder(order);
        }
    }
}
