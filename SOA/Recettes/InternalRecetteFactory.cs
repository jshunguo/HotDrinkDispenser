using SOA.Products;
using System;

namespace SOA.Recettes
{
    internal class InternalRecetteFactory : IRecetteFactory
    {
        private readonly IProductRepository _productRepository;

        public InternalRecetteFactory(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public RecetteBase Create(string recetteName)
        {
            var recette = CreateInternal(recetteName);
            recette.Initialize();
            return recette;
        }

        private RecetteBase CreateInternal(string recetteName)
        {
            if (string.IsNullOrEmpty(recetteName)) throw new ArgumentNullException(nameof(recetteName));

            switch (recetteName)
            {
                case RecetteNames.Chocolat:
                    return new ChocolatRecette(_productRepository);
                default:
                    throw new InvalidOperationException($"Cannot create recette of type {recetteName}");
            }
        }
    }

    internal static class RecetteNames
    {
        public const string Expresso = "Expresso";
        public const string Allonge = "Allongé";
        public const string Capuccino = "Capuccino";
        public const string Chocolat = "Chocolat";
        public const string The = "Thé";
    }
}
