using Microsoft.EntityFrameworkCore;
using ProductTest.Entities;

namespace ProductTest.Repositories
{
    public class ProductRepository : IProductRepository
    {

        private readonly ProductTestContext context;
        public ProductRepository(ProductTestContext _ProductTestContext)
        {
            this.context = _ProductTestContext;
        }

        public Product insert(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
            return product;
        }

        public Product update(Product product)
        {
            context.Products.Update(product);

            context.SaveChanges();
            return product;
        }

        public void delete(Product product) 
        { 
            context.Products.Remove(product);

            context.SaveChanges();
        }

        public Product? GetProduct(int id)
        {
            return context.Products.Where(p => p.Upc == id).FirstOrDefault();
        }

        public List<Product> GetAll()
        {
            return context.Products.ToList();
        }

    }
}
