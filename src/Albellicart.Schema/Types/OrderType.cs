using Albellicart.Models;
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
            Field(f => f.Id).Description("Id of an Order");
            Field(f => f.OrderLine, type: typeof(ListGraphType<OrderLineType>))
                .Description("List of Products and their quantitites in an Order");
            Field(f => f.RequiredBinWidth).Description("Required Bin Width in millimeters (mm)");
        }
    }
}
