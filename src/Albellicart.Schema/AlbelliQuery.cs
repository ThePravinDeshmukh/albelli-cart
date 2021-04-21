using GraphQL;
using GraphQL.Types;
using Albellicart.Schema.Types;
using Albellicart.Schema.Core;
using Albellicart.BusinessLogic;

namespace Albellicart.Schema
{
    public partial class AlbelliQuery : ObjectGraphType<object>
    {
        public AlbelliQuery(IOrderLogic orderLogic)
        {
            Name = Constants.AlbelliQuery.Name;

            // Query for getting all orders
            Field<ListGraphType<OrderType>>(Constants.AlbelliQuery.Orders, resolve: context => orderLogic.GetOrders());

            // Query for getting an order
            Field<OrderType>(
                Constants.AlbelliQuery.Order,
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = Constants.AlbelliQuery.Id, Description = Constants.AlbelliQuery.IdDescription }
                ),
                resolve: context => orderLogic.GetOrder(context.GetArgument<int>(Constants.AlbelliQuery.Id))
            );

        }
    }
}
