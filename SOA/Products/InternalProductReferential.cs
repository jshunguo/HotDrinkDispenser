using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOA.Products
{
    internal class InternalProductReferential : IProductReferential
    {
        private readonly Dictionary<string, decimal> PriceByName = new Dictionary<string, decimal>
        {
            {ProductNames.Cafe, 1 },
            {ProductNames.Chocolat, 1 },
            {ProductNames.Creme, new decimal(0.5) },
            {ProductNames.Eau, new decimal(0.2) },
            {ProductNames.Lait, new decimal(0.4) },
            {ProductNames.Sucre, new decimal(0.1) },
            {ProductNames.The, 2 },
        };

        public decimal GetPrice(string productName)
        {
            if (string.IsNullOrEmpty(productName)) throw new ArgumentNullException(nameof(productName));

            if(PriceByName.TryGetValue(productName, out var price))
            {
                return price;
            }

            throw new InvalidOperationException($"Cannot find Price of Product {productName}");
        }
    }

    internal static class ProductNames
    {
        public const string Cafe = "Café";
        public const string Sucre = "Sucre";
        public const string Creme = "Crème";
        public const string The = "Thé";
        public const string Eau = "Eau";
        public const string Chocolat = "Chocolat";
        public const string Lait = "Lait";
    }
}
