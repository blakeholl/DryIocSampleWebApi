using System.Collections.Generic;
using System.Web.Http;

namespace DryIocSampleWebApi.Controllers
{
    public class ProductsController : ApiController
    {
        private readonly ProductRepository _productRepository;

        public ProductsController(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IHttpActionResult Get()
        {
            return Ok(_productRepository.List());
        }

        public IHttpActionResult Get(int id)
        {
            var found = _productRepository.GetById(id);

            if (found == null)
            {
                return NotFound();
            }

            return Ok(found);
        }
    }
}