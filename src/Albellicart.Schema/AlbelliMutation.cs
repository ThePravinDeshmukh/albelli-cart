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
    ///   "query": "mutation ($human:HumanInput!){ createOrder(human: $human) { id name } }",
    ///   "variables": {
    ///     "human": {
    ///       "name": "Boba Fett"
    ///     }
    ///   }
    /// }
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
                    return orderLogic.AddOrder(orderLines);
                });
        }
    }
}
