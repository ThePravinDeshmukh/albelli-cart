using Xunit;
using Albellicart.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using Albellicart.Models.Repository;
using Albellicart.Models;

namespace Albellicart.BusinessLogic.Tests
{
    public class OrderLogicTests
    {
        OrderLogic target;
        Mock<IOrderLogic> targetMock;
        Mock<IOrderRepository> orderRepositoryMock;
        IProductRepository productRepository;
        Mock<IOrder> orderMock;
        IOrder order;
        public OrderLogicTests()
        {
            orderRepositoryMock = new Mock<IOrderRepository>();
            productRepository = new ProductRepository();
            orderMock = new Mock<IOrder>();
            order = new Order();

            target = new OrderLogic(
                orderRepositoryMock.Object,
                productRepository);
            targetMock = new Mock<IOrderLogic>();
        }

        [Fact()]
        public void ShouldCallOrderRepository_GetOrdersTest()
        {
            target.GetOrders();

            orderRepositoryMock.Verify(m => m.GetOrders(), Times.Once);
        }

        [Fact()]
        public void ShouldCallOrderRepository_GetOrderTest()
        {
            target.GetOrder(It.IsAny<int>());

            orderRepositoryMock.Verify(m => m.GetOrder(It.IsAny<int>()), Times.Once);
        }

        [Fact()]
        public void ShouldThrowExceptionWhenOrderIsNull_AddOrderTest()
        {
            // Arrange
            Order order = null;

            // Act & Assert
            Assert.Throws<Exception>(() => target.AddOrder(order));
        }

        [Fact()]
        public void ShouldThrowExceptionWhenOrderLinesIsNull_AddOrderTest()
        {
            // Arrange
            Order order = new Order { OrderLine = null };

            // Act & Assert
            Assert.Throws<Exception>(() => target.AddOrder(order));
        }

        [Fact()]
        public void ShouldThrowExceptionWhenOrderLinesIsExpty_AddOrderTest()
        {
            // Arrange
            Order order = new Order { OrderLine = new List<OrderLine>() };

            // Act & Assert
            Assert.Throws<Exception>(() => target.AddOrder(order));
        }

        [Fact()]
        public void ShouldReturnOrderBack_AddOrderTest()
        {
            // Arrange
            Order order = new Order { OrderLine = new List<OrderLine> { new OrderLine { ProductType = Models.Enums.ProductType.Calendar, Quantity = 2 } } };

            // Act
            var output = target.AddOrder(order);

            // Assert
            orderRepositoryMock.Verify(m => m.AddOrder(order), Times.Once);
            Assert.NotNull(output);
        }

        /// <summary>
        /// This is test data for orders with different combination of Product & their quantities
        /// You can add
        /// </summary>
        public static IEnumerable<object[]> TestOrderData =>
            new List<object[]>
            {
                new object[] {
                    137.7,
                    new Order{
                        OrderLine =  new List<OrderLine>
                        {
                            new OrderLine {ProductType = Models.Enums.ProductType.PhotoBook, Quantity = 1},
                            new OrderLine {ProductType = Models.Enums.ProductType.Calendar, Quantity = 2},
                            new OrderLine {ProductType = Models.Enums.ProductType.Cards, Quantity = 1},
                            new OrderLine {ProductType = Models.Enums.ProductType.Mug, Quantity = 1},
                        }
                    }
                },
                new object[] {
                    137.7,
                    new Order{
                        OrderLine =  new List<OrderLine>
                        {
                            new OrderLine {ProductType = Models.Enums.ProductType.PhotoBook, Quantity = 1},
                            new OrderLine {ProductType = Models.Enums.ProductType.Calendar, Quantity = 2},
                            new OrderLine {ProductType = Models.Enums.ProductType.Cards, Quantity = 1},
                            new OrderLine {ProductType = Models.Enums.ProductType.Mug, Quantity = 2},
                        }
                    }
                },
                new object[] {
                    137.7,
                    new Order{
                        OrderLine =  new List<OrderLine>
                        {
                            new OrderLine {ProductType = Models.Enums.ProductType.PhotoBook, Quantity = 1},
                            new OrderLine {ProductType = Models.Enums.ProductType.Calendar, Quantity = 2},
                            new OrderLine {ProductType = Models.Enums.ProductType.Cards, Quantity = 1},
                            new OrderLine {ProductType = Models.Enums.ProductType.Mug, Quantity = 3},
                        }
                    }
                },
                new object[] {
                    137.7,
                    new Order{
                        OrderLine =  new List<OrderLine>
                        {
                            new OrderLine {ProductType = Models.Enums.ProductType.PhotoBook, Quantity = 1},
                            new OrderLine {ProductType = Models.Enums.ProductType.Calendar, Quantity = 2},
                            new OrderLine {ProductType = Models.Enums.ProductType.Cards, Quantity = 1},
                            new OrderLine {ProductType = Models.Enums.ProductType.Mug, Quantity = 4},
                        }
                    }
                },
                new object[] {
                    231.7,
                    new Order{
                        OrderLine =  new List<OrderLine>
                        {
                            new OrderLine {ProductType = Models.Enums.ProductType.PhotoBook, Quantity = 1},
                            new OrderLine {ProductType = Models.Enums.ProductType.Calendar, Quantity = 2},
                            new OrderLine {ProductType = Models.Enums.ProductType.Cards, Quantity = 1},
                            new OrderLine {ProductType = Models.Enums.ProductType.Mug, Quantity = 5},
                        }
                    }
                },
            };

        [Theory]
        [MemberData(nameof(TestOrderData))]
        public void ShouldReturnRequiredMinWidth_AddOrderTest(double expectedRequiredMinWidth, Order order)
        {
            // Act
            var output = target.AddOrder(order);

            // Assert
            Assert.Equal(expectedRequiredMinWidth, order.RequiredBinWidth);
        }


    }
}