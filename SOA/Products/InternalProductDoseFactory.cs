using System;

namespace SOA.Products
{
    internal class InternalProductDoseFactory : IProductDoseFactory
    {
        private readonly IProductReferential _productReferential;
        private readonly Product _product;

        public InternalProductDoseFactory(IProductReferential productReferential, Product product)
        {
            _productReferential = productReferential;
            _product = product;
        }

        public IProductDose Create(uint quantity = 1)
        {
            var price = quantity * _productReferential.GetPrice(_product.Name);
            return new InternalProductDose(quantity, price, _product);
        }
    }
}
