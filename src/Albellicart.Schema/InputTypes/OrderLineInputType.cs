using Albellicart.Models;
using GraphQL.Types;
using Albellicart.Schema.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Albellicart.Schema.Types
{
    public class OrderLineInputType : InputObjectGraphType<OrderLine>
    {
        public OrderLineInputType()
        {
            Name = "OrderLine";

            Field(f => f.ProductType, nullable: false, type: typeof(ProductTypeEnum)).Description("Product Type in Order");
            Field(f => f.Quantity, nullable: false).Description("Product Quantity in Order");
        }
    }
}
