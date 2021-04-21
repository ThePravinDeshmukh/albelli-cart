using Xunit;
using Albellicart.Schema;
using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using Albellicart.Models.Repository;
using Albellicart.BusinessLogic;
using GraphQL.Utilities;
using System.Linq;
using FluentAssertions;

namespace Albellicart.Schema.Behaviour
{
    public class AlbelliSchemaTests
    {
        private readonly AlbelliSchema albelliSchema;
        private readonly Mock<IOrderLogic> orderLogic;
        private readonly Mock<IServiceProvider> mockServiceProvider;

        public AlbelliSchemaTests()
        {
            orderLogic = new Mock<IOrderLogic>();

            mockServiceProvider = new Mock<IServiceProvider>();

            mockServiceProvider
                .Setup(x => x.GetService(typeof(AlbelliQuery)))
                .Returns(new AlbelliQuery(orderLogic.Object));
            mockServiceProvider
                .Setup(x => x.GetService(typeof(AlbelliMutation)))
                .Returns(new AlbelliMutation(orderLogic.Object));

            albelliSchema = new AlbelliSchema(mockServiceProvider.Object);
        }

        [Fact()]
        public void AlbelliSchemaTest()
        {
            albelliSchema.Query.Fields.Count().Should().Be(2);
            albelliSchema.Mutation.Fields.Count().Should().Be(1);

        }
    }
}