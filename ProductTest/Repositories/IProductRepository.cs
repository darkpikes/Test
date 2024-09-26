using ProductTest.Entities;

namespace ProductTest.Repositories
{
    public interface IProductRepository
    {
        Product insert(Product product);

        Product update(Product product);
        void delete(Product product);
        Product? GetProduct(int id);
        List<Product> GetAll();
    }
}
