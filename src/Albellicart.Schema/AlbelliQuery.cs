using System;
using GraphQL;
using GraphQL.Types;
using Albellicart.Schema.Types;
using Albellicart.Schema.Core;
using Albellicart.Models.Repository;

namespace Albellicart.Schema
{
    public partial class AlbelliQuery : ObjectGraphType<object>
    {
        public AlbelliQuery(IOrderRepository orderRepository)
        {
            Name = QueryName.AlbelliQuery;

            // Query for getting all orders
            Field<ListGraphType<OrderType>>("orders", resolve: context => orderRepository.GetOrders());


            // Query for getting an order
            Field<OrderType>(
                "order",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "id", Description = "Id of an order" }
                ),
                resolve: context => orderRepository.GetOrder(context.GetArgument<int>("id"))
            );

            //Func<IResolveFieldContext, string, object> func = (context, id) => data.GetDroidByIdAsync(id);

            //FieldDelegate<DroidType>(
            //    "droid",
            //    arguments: new QueryArguments(
            //        new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "id", Description = "id of the droid" }
            //    ),
            //    resolve: func
            //);
        }
    }
}
