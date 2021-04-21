using System;
using GraphQL;
using GraphQL.Types;
using Albellicart.Schema.Types;
using Albellicart.Schema.Core;
using Albellicart.Models.Repository;
using Albellicart.BusinessLogic;

namespace Albellicart.Schema
{
    public partial class AlbelliQuery : ObjectGraphType<object>
    {
        public AlbelliQuery(IOrderLogic orderLogic)
        {
            Name = QueryName.AlbelliQuery;

            // Query for getting all orders
            Field<ListGraphType<OrderType>>("orders", resolve: context => orderLogic.GetOrders());

            // Query for getting an order
            Field<OrderType>(
                "order",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "id", Description = "Id of an order" }
                ),
                resolve: context => orderLogic.GetOrder(context.GetArgument<int>("id"))
            );

        }
    }
}
