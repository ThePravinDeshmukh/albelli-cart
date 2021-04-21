using Albellicart.Models;
using GraphQL.Types;
using Albellicart.Schema.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Albellicart.Schema.Core;

namespace Albellicart.Schema.Types
{
    public class OrderLineType : ObjectGraphType<OrderLine>
    {
        public OrderLineType()
        {
            Field(f => f.ProductType, type: typeof(ProductTypeEnum), nullable: false)
                .Description(Constants.OrderLineType.ProductTypeDescription);

            Field(f => f.Quantity, nullable: false)
                .Description(Constants.OrderLineType.QuantityDescription);
        }
    }
}
