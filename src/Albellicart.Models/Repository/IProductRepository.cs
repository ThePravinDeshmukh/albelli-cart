using System.Collections.Generic;

namespace Albellicart.Models.Repository
{
    public interface IProductRepository
    {

        IEnumerable<Product> GetProducts();
        Product GetProduct(int id);
    }
}