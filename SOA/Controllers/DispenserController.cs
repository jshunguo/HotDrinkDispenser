using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SOA.Products;
using SOA.Recettes;

namespace SOA.Controllers
{
    [Route("api/dispenser")]
    [ApiController]
    public class DispenserController : ControllerBase
    {
        private IRecetteFactory _recetteFactory;

        public DispenserController()
        {
            _recetteFactory = new InternalRecetteFactory(new InternalProductRepository());
        }
        // GET api/dispenser
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { RecetteNames.Allonge, RecetteNames.Capuccino, RecetteNames.Chocolat, RecetteNames.Expresso, RecetteNames.The };
        }

        // GET api/dispenser/5
        [HttpGet("{recetteName}")]
        public ActionResult<decimal> Get(string recetteName)
        {
            var marge = new decimal(1.3);
            var recette = _recetteFactory.Create(recetteName);
            return recette.GetPrice() * marge;
        }
    }
}
