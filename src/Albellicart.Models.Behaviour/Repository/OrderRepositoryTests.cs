using Xunit;
using Albellicart.Models.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Data.Common;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Data.Sqlite;

namespace Albellicart.Models.Repository.Behaviour
{
    public class OrderRepositoryTests
    {
        public OrderRepositoryTests()
        {
            
            DbContextOptions<AlbellicartContext> contextOptions = new DbContextOptionsBuilder<AlbellicartContext>()
                    .UseInMemoryDatabase("Albellicart")
                    .Options;

            ContextOptions = contextOptions;
            Seed();
        }

        private void Seed()
        {
            using (var context = new AlbellicartContext(ContextOptions))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                var order = new Order
                {
                    OrderLine = new List<OrderLine>
                    {
                        new OrderLine {ProductType = Enums.ProductType.Calendar, Quantity = 1},
                        new OrderLine {ProductType = Enums.ProductType.Canvas, Quantity = 2},
                        new OrderLine {ProductType = Enums.ProductType.Cards, Quantity = 3},
                    }
                };

                context.AddRange(order);

                context.SaveChanges();
            }
        }

        protected DbContextOptions<AlbellicartContext> ContextOptions { get; }

        [Fact]
        public void Can_GetOrder_By_Id()
        {
            using (var context = new AlbellicartContext(ContextOptions))
            {
                var controller = new OrderRepository(context);

                var order = controller.GetOrder(1);

                Assert.Equal(1, order.Id);
                Assert.Equal(3, order.OrderLine.Count());
            }
        }

        [Fact]
        public void Can_GetOrders()
        {
            using (var context = new AlbellicartContext(ContextOptions))
            {
                var controller = new OrderRepository(context);

                var order = controller.GetOrders();

                Assert.Single(order);
                Assert.Equal(3, order.First().OrderLine.Count());
            }
        }

        [Fact]
        public void Can_AddOrder()
        {
            using (var context = new AlbellicartContext(ContextOptions))
            {
                var controller = new OrderRepository(context);

                var existingOrder = controller.GetOrder(1);

                existingOrder.Id = 0;

                var newOrder = controller.AddOrder(existingOrder);

                Assert.NotNull(newOrder);
                Assert.Equal(3, newOrder.OrderLine.Count());
            }
        }

    }
}