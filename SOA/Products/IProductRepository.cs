using System.Collections.Generic;

namespace SOA.Products
{
    public interface IProductRepository
    {
        Product GetByName(string productName);
    }
}
