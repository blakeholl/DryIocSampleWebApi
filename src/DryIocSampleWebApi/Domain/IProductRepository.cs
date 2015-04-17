using System.Collections.Generic;

namespace DryIocSampleWebApi.Domain
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();
        Product GetById(int id);
    }
}