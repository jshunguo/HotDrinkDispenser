using SOA.Products;

namespace SOA.Products
{
    public interface IProductDose
    {
        uint Quantity { get; }
        decimal Price { get; }
        Product Product { get; }
    }
}
