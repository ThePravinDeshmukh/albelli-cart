namespace Albellicart.Schema.Core
{
    public static class Constants
    {
        public static class AlbelliQuery
        {
            public const string Name = "AlbelliQuery";
            public const string Orders = "orders";
            public const string Order = "order";
            public const string Id = "id";
            public const string IdDescription = "Id of an order";
        }
        public static class OrderLineType
        {
            public const string ProductTypeDescription = "Product Type in Order";
            public const string QuantityDescription = "Product Quantity in Order";
        }
        public static class OrderType
        {
            public const string IdDescription = "Id of an Order";
            public const string OrderLineDescription = "List of Products and their quantitites in an Order";
            public const string OrderLineRequiredBinWidth = "Required Bin Width in millimeters (mm)";
        }
        public static class ProductTypeEnum
        {
            public const string Name = "ProductType";
        }
        public static class AlbelliMutation
        {
            public const string Name = "Mutation";
            public const string OrderTypeName = "createOrder";
            public const string OrderTypeOrderlines = "orderlines";
        }

    }
}
