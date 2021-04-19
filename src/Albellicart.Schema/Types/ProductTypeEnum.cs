using Albellicart.Models.Enums;
using GraphQL.Types;

namespace Albellicart.Schema.Types
{
    public class ProductTypeEnum : EnumerationGraphType<ProductType>
    {
        public ProductTypeEnum()
        {
            Name = "ProductType";
            AddValue(nameof(ProductType.PhotoBook), null, ProductType.PhotoBook);
            AddValue(nameof(ProductType.Calendar), null, ProductType.Calendar);
            AddValue(nameof(ProductType.Canvas), null, ProductType.Canvas);
            AddValue(nameof(ProductType.Cards), null, ProductType.Cards);
            AddValue(nameof(ProductType.Mug), null, ProductType.Mug);
        }
    }

}
