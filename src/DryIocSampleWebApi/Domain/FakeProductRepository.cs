using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace DryIocSampleWebApi.Domain
{
    public class FakeProductRepository : IProductRepository
    {
        private readonly IList<Product> _products = new List<Product>
        {
            new Product {Id = 1, Name = "Bubblegum"},
            new Product {Id = 2, Name = "Candy"}
        };

        public FakeProductRepository()
        {
            Debug.WriteLine(GetType().Name + " ctor");
        }

        public IEnumerable<Product> GetAll()
        {
            return _products;
        }

        public Product GetById(int id)
        {
            return _products.FirstOrDefault(p => p.Id == id);
        }
    }
}
