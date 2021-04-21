using Xunit;
using Albellicart.Schema;
using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using Albellicart.BusinessLogic;
using System.Linq;
using FluentAssertions;
using Albellicart.Schema.Types;
using Albellicart.Models;
using GraphQL.Types;
using GraphQL;

namespace Albellicart.Schema.Behaviour
{
    public class AlbelliMutationTests
    {
        private readonly AlbelliMutation albelliMutation;
        private readonly Mock<IOrderLogic> mockOrderLogic;
        private readonly Mock<IResolveFieldContext> mockResolveFieldContext;

        public AlbelliMutationTests()
        {
            mockOrderLogic = new Mock<IOrderLogic>();
            mockResolveFieldContext = new Mock<IResolveFieldContext>();

            albelliMutation = new AlbelliMutation(mockOrderLogic.Object);
        }

        [Fact()]
        public void CreateOrder_Should_Have_Valid_Arguments()
        {
            var targetType = albelliMutation.Fields.FirstOrDefault(x => x.Name == "createOrder");

            Assert.NotNull(targetType);
            targetType.Type.Should().Be(typeof(OrderType));
            targetType.Arguments.First().Type.Should().Be(typeof(NonNullGraphType<ListGraphType<OrderLineInputType>>));
            targetType.Arguments.Count.Should().Be(1);
            targetType.Arguments[0].Name.Should().Be("orderlines");

            targetType.Resolver.Resolve(mockResolveFieldContext.Object);
        }
    }
}