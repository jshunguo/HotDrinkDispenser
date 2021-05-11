using System.Collections.Generic;
using SOA.Products;

namespace SOA.Recettes
{
    public class ChocolatRecette : RecetteBase
    {
        public ChocolatRecette(IProductRepository productRepository) : base(productRepository)
        {
        }

        public override string Name => "Chocolat";

        protected override IReadOnlyCollection<IProductDose> PopulateIngredients()
        {
            var sucre = ProductRepository.GetByName(ProductNames.Sucre);
            var lait = ProductRepository.GetByName(ProductNames.Lait);
            var eau = ProductRepository.GetByName(ProductNames.Eau);
            var chocolat = ProductRepository.GetByName(ProductNames.Chocolat);

            return new List<IProductDose>
            {
                sucre.DoseFactory.Create(),
                eau.DoseFactory.Create(),
                lait.DoseFactory.Create(2),
                chocolat.DoseFactory.Create(3)
            };
        }
    }
}
