using GraphQL;
using GraphQL.Types;
using Albellicart.Schema.Types;
using Albellicart.Models.Repository;
using Albellicart.Models;
using Albellicart.BusinessLogic;
using System.Collections.Generic;

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
            Name = "Mutation";


            Field<OrderType>(
                "createOrder",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<ListGraphType<OrderLineInputType>>> { Name = "orderlines" }
                ),
                resolve: context =>
                {
                    var orderLines = context.GetArgument<IEnumerable<OrderLine>>("orderlines");


                    return orderLogic.AddOrder(new Order { OrderLine = orderLines });
                });
        }
    }
}
