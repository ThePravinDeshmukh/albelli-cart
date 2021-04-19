using Albellicart.Models;
using Albellicart.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Albellicart.BusinessLogic
{
    public class OrderLogic : IOrderLogic
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        public OrderLogic(IOrderRepository orderRepository, IProductRepository productRepository)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
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
                OrderLine = orderLines.ToList()
            };

            SetRequiredBinWidth(order);

            return _orderRepository.AddOrder(order);
        }

        private void SetRequiredBinWidth(Order order)
        {
            order.RequiredBinWidth = order
                .OrderLine.Join(_productRepository.GetProducts(),
                      x => x.ProductType,
                      y => y.ProductType,
                      (x, y) => Math.Ceiling((double)x.Quantity / y.WidthFactor) * y.WidthInmm)
                .Sum()
                ;
        }

        private void SetId(Order order)
        {
            order.Id = _orderRepository.GetOrders().Count() + 1;
        }
    }
}
