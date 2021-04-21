using Xunit;
using Albellicart.Schema;
using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using Albellicart.Models.Repository;
using System.Linq;
using Albellicart.Schema.Types;
using FluentAssertions;
using GraphQL.Types;
using Albellicart.BusinessLogic;

namespace Albellicart.Schema.Behaviour
{
    public class AlbelliQueryTests
    {
        private readonly AlbelliQuery albelliQuery;
        private readonly Mock<IOrderLogic> mockOrderLogic;

        public AlbelliQueryTests()
        {
            mockOrderLogic = new Mock<IOrderLogic>();

            albelliQuery = new AlbelliQuery(mockOrderLogic.Object);
        }

        [Fact()]
        public void GetOrderQuery_Should_Have_Valid_Arguments()
        {
            var targetType = albelliQuery.Fields.FirstOrDefault(x => x.Name == "order");

            Assert.NotNull(targetType);
            targetType.Type.Should().Be(typeof(OrderType));
            targetType.Arguments.Count.Should().Be(1);
            targetType.Arguments[0].Name.Should().Be("id");
        }

        [Fact()]
        public void GetOrdersQuery_Should_Have_Valid_Arguments()
        {
            var targetType = albelliQuery.Fields.FirstOrDefault(x => x.Name == "orders");

            Assert.NotNull(targetType);
            targetType.Type.Should().Be(typeof(ListGraphType<OrderType>));
            targetType.Arguments.Should().BeNull();
        }
    }
}