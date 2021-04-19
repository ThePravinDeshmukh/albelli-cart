using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Albellicart.Models.Repository
{
    public class ProductRepository : IProductRepository
    {

        private readonly List<Product> Products;
        public ProductRepository()
        {
            Products = new List<Product>
            {
                new Product {ProductType = Enums.ProductType.PhotoBook, WidthFactor = 1, WidthInmm = 19},
                new Product {ProductType = Enums.ProductType.Calendar , WidthFactor = 1, WidthInmm = 10},
                new Product {ProductType = Enums.ProductType.Canvas, WidthFactor = 1, WidthInmm = 16},
                new Product {ProductType = Enums.ProductType.Cards, WidthFactor = 1, WidthInmm = 4.7},
                new Product {ProductType = Enums.ProductType.Mug, WidthFactor = 4, WidthInmm = 94},
            };
        }

        public IEnumerable<Product> GetProducts()
        {
            return Products;
        }
        public Product GetProduct(int id)
        {
            return Products.FirstOrDefault(x => (int)(x.ProductType) == id);
        }
    }
}
