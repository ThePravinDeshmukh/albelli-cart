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
        private readonly OrderLogic target;

        private readonly Mock<IOrderRepository> orderRepositoryMock;
        private readonly IProductRepository productRepository;

        /// <summary>
        /// This is test data for orders with different combination of Product & their quantities
        /// You can add more Orders in TestOrderData List with different combination of products and Quantities to cover edge cases.
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
                            new OrderLine {ProductType = Models.Enums.ProductType.Mug, Quantity = 1}, // Mug Qunatity 1
                        }
                    }
                },
                // Mug Qunatity 2 and everything else same as previous order should have no change on RequiredMinWidth
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
                // Mug Qunatity 3 and everything else same as previous order should have no change on RequiredMinWidth
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
                // Mug Qunatity 4 and everything else same as previous order should have no change on RequiredMinWidth
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
                // Mug Qunatity 5 and everything else same as previous order should add width of one more mug to RequiredMinWidth
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
                }
            };
        public OrderLogicTests()
        {
            orderRepositoryMock = new Mock<IOrderRepository>();
            productRepository = new ProductRepository();

            target = new OrderLogic(
                orderRepositoryMock.Object,
                productRepository);
        }

        [Fact()]
        public void Should_Call_Order_Repository_GetOrdersTest()
        {
            target.GetOrders();

            orderRepositoryMock.Verify(m => m.GetOrders(), Times.Once);
        }

        [Fact()]
        public void Should_Call_Order_Repository_GetOrderTest()
        {
            target.GetOrder(It.IsAny<int>());

            orderRepositoryMock.Verify(m => m.GetOrder(It.IsAny<int>()), Times.Once);
        }

        [Fact()]
        public void Should_Throw_Exception_When_Order_IsNull_AddOrderTest()
        {
            // Arrange
            Order order = null;

            // Act & Assert
            Assert.Throws<Exception>(() => target.AddOrder(order));
        }

        [Fact()]
        public void Should_Throw_Exception_When_Order_Lines_IsNull_AddOrderTest()
        {
            // Arrange
            Order order = new Order { OrderLine = null };

            // Act & Assert
            Assert.Throws<Exception>(() => target.AddOrder(order));
        }

        [Fact()]
        public void Should_Throw_Exception_When_Order_Lines_IsExpty_AddOrderTest()
        {
            // Arrange
            Order order = new Order { OrderLine = new List<OrderLine>() };

            // Act & Assert
            Assert.Throws<Exception>(() => target.AddOrder(order));
        }

        [Fact()]
        public void Should_Throw_Exception_When_Order_Has_All_Zero_Qty_Products_AddOrderTest()
        {
            // Arrange
            Order order = new Order { 
                OrderLine = new List<OrderLine> 
                {
                    new OrderLine { ProductType = Models.Enums.ProductType.Calendar , Quantity = 0 },
                    new OrderLine { ProductType = Models.Enums.ProductType.Canvas , Quantity = 0 },
                } 
            };

            // Act & Assert
            Assert.Throws<Exception>(() => target.AddOrder(order));
        }

        [Theory]
        [MemberData(nameof(TestOrderData))]
        public void Should_Return_Required_Min_Width_AddOrderTest(double expectedRequiredMinWidth, Order order)
        {
            // Act
            target.AddOrder(order);

            // Assert
            Assert.Equal(expectedRequiredMinWidth, order.RequiredBinWidth);
        }


    }
}