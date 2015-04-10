using System.Collections.Generic;
using System.Linq;

namespace DryIocSampleWebApi
{
    public class ProductRepository
    {
        private readonly IList<Product> _products = new List<Product>
        {
            new Product {Id = 1, Name = "Bubblegum"},
            new Product {Id = 2, Name = "Candy"}
        };

        public IEnumerable<Product> List()
        {
            return _products;
        }

        public Product GetById(int id)
        {
            return _products.FirstOrDefault(p => p.Id == id);
        }
    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
