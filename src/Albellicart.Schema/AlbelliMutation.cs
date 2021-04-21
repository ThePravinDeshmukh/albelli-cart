using GraphQL;
using GraphQL.Types;
using Albellicart.Schema.Types;
using Albellicart.Models.Repository;
using Albellicart.Models;
using Albellicart.BusinessLogic;
using System.Collections.Generic;
using Albellicart.Schema.Core;

namespace Albellicart.Schema
{
    /// <example>
    /// This is an example JSON request for a mutation
    /// {
    ///   "query": "mutation ($orderlines:[OrderLine]!) { createOrder(orderlines: $orderlines) { id, requiredBinWidth, orderLine {productType, quantity } } }",
    ///   "variables": {
    ///        "orderlines": [
    ///        { "productType": "PHOTO_BOOK","quantity": 13},
    ///        { "productType": "CALENDAR","quantity": 2},
    ///        { "productType": "MUG","quantity": 7}
    ///        ]
    ///    }
    /// </example>
    public class AlbelliMutation : ObjectGraphType
    {
        public AlbelliMutation(IOrderLogic orderLogic)
        {
            Name = Constants.AlbelliMutation.Name;

            Field<OrderType>(
                Constants.AlbelliMutation.OrderTypeName,
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<ListGraphType<OrderLineInputType>>> { Name = Constants.AlbelliMutation.OrderTypeOrderlines }
                ),
                resolve: context =>
                {
                    var orderLines = context.GetArgument<IEnumerable<OrderLine>>(Constants.AlbelliMutation.OrderTypeOrderlines);

                    return orderLogic.AddOrder(new Order { OrderLine = orderLines });
                });
        }
    }
}
