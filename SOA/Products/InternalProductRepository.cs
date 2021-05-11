namespace SOA.Products
{
    internal class InternalProductRepository : IProductRepository
    {
        public Product GetByName(string productName)
        {
            return new Product(productName);
        }
    }
}
