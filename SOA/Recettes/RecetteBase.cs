using SOA.Products;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SOA.Recettes
{
    public abstract class RecetteBase
    {
        private bool _isInitialized;
        private IReadOnlyCollection<IProductDose> _productDoses;

        public Guid Id { get; }

        public abstract string Name { get; }

        public IReadOnlyCollection<IProductDose> Ingredients
        {
            get
            {
                Initialize();
                return _productDoses;
            }
        }

        protected IProductRepository ProductRepository { get; }

        protected RecetteBase(IProductRepository productRepository)
        {
            Id = Guid.NewGuid();
            ProductRepository = productRepository;
        }

        public void Initialize()
        {
            if (_isInitialized) return;

            _productDoses = PopulateIngredients();

            _isInitialized = _productDoses != null && _productDoses.Count > 0;
        }

        public decimal GetPrice()
        {
            return Ingredients.Sum(item => item.Price);
        }

        protected abstract IReadOnlyCollection<IProductDose> PopulateIngredients();
    }
}
