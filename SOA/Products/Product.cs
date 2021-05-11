using System;

namespace SOA.Products
{
    public class Product : IEquatable<Product>
    {
        public string Name { get; }

        public IProductDoseFactory DoseFactory { get; }

        public Product(string name, IProductDoseFactory doseFactory)
        {
            Name = name;
            DoseFactory = doseFactory;
        }

        public Product(string name, IProductReferential productReferential)
        {
            Name = name;
            DoseFactory = new InternalProductDoseFactory(productReferential, this);
        }

        public Product(string name):this(name, new InternalProductReferential())
        {

        }

        bool IEquatable<Product>.Equals(Product other)
        {
            return Equals(other);
        }

        public override bool Equals(object obj)
        {
            var other = obj as Product;
            return string.Equals(other.Name, Name, StringComparison.OrdinalIgnoreCase);
        }

        public override int GetHashCode()
        {
            var hash = 0;
            if (!string.IsNullOrEmpty(Name))
            {
                hash ^= Name.GetHashCode();
            }
            return hash;
        }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
