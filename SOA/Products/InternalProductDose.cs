using System;

namespace SOA.Products
{
    internal class InternalProductDose : IProductDose
    {
        public uint Quantity { get; }

        public decimal Price { get; }

        public Product Product { get; }

        public InternalProductDose(uint quantity, decimal price, Product product)
        {
            Quantity = quantity;
            Price = price;
            Product = product;
        }
    }
}
