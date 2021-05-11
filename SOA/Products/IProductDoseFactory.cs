using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOA.Products
{
    public interface IProductDoseFactory
    {
        IProductDose Create(uint quantity = 1);
    }
}
