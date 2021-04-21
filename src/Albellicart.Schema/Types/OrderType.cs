using Albellicart.Models;
using Albellicart.Schema.Core;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Albellicart.Schema.Types
{
    public class OrderType : ObjectGraphType<Order>
    {
        public OrderType()
        {
            Field(f => f.Id).Description(Constants.OrderType.IdDescription);
            Field(f => f.OrderLine, type: typeof(ListGraphType<OrderLineType>))
                .Description(Constants.OrderType.OrderLineDescription);
            Field(f => f.RequiredBinWidth).Description(Constants.OrderType.OrderLineRequiredBinWidth);
        }
    }
}
