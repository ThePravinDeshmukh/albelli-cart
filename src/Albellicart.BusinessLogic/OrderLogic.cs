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
        public Order AddOrder(Order order)
        {
            if (order == null || order.OrderLine == null || order.OrderLine.Count() == 0)
            {
                throw new Exception("Order cannot be empty. Please add product and quantity.");
            }

            if (GetCountAfterRemovingZeroQtyProducts(order) == 0)
            {
                throw new Exception("Order cannot have products without valid quantity. Please add product and valid quantity.");
            }

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

        private int GetCountAfterRemovingZeroQtyProducts(Order order)
        {
            var orderlines = order
                .OrderLine
                .ToList();

            orderlines.RemoveAll(x => x.Quantity == 0);

            order.OrderLine = orderlines;

            return order.OrderLine.Count();
        }
    }
}
