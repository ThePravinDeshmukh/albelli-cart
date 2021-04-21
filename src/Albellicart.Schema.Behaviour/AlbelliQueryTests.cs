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
using GraphQL;

namespace Albellicart.Schema.Behaviour
{
    public class AlbelliQueryTests
    {
        private readonly AlbelliQuery albelliQuery;
        private readonly Mock<IOrderLogic> mockOrderLogic;
        private readonly Mock<IResolveFieldContext> mockResolveFieldContext;

        public AlbelliQueryTests()
        {
            mockOrderLogic = new Mock<IOrderLogic>();
            mockResolveFieldContext = new Mock<IResolveFieldContext>();

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

            targetType.Resolver.Resolve(mockResolveFieldContext.Object);
        }

        [Fact()]
        public void GetOrdersQuery_Should_Have_Valid_Arguments()
        {
            var targetType = albelliQuery.Fields.FirstOrDefault(x => x.Name == "orders");

            Assert.NotNull(targetType);
            targetType.Type.Should().Be(typeof(ListGraphType<OrderType>));
            targetType.Arguments.Should().BeNull();

            targetType.Resolver.Resolve(mockResolveFieldContext.Object);
        }
    }
}