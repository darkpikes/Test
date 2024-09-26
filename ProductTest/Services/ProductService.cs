using Microsoft.EntityFrameworkCore.Query;
using ProductTest.Entities;
using ProductTest.Models;
using ProductTest.Repositories;

namespace ProductTest.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository repo;
        public ProductService(IProductRepository r) 
        {
            repo = r;
        }

        public ProductDTO? GetProduct(int UPC)
        {
            return Map(repo.GetProduct(UPC));
        }

        public List<ProductDTO?> GetAll()
        {
            return Map(repo.GetAll());
        }

        public ProductDTO? InsertProduct(ProductInsertDTO prod)
        {
            var result = repo.insert(Map(prod));
            return Map(result);
        }

        public ProductDTO? EditProduct(ProductDTO prod)
        {
            var old = repo.GetProduct(prod.Upc);
            if(old == null) return null;
            old.CurrentPrice = prod.CurrentPrice;
            old.Quantity = prod.Quantity;
            old.Description = prod.Description;

            var result = repo.update(old);

            return Map(result);
        }

        public void DeleteProduct(int UPC)
        {
            var result = repo.GetProduct(UPC);
            if(result != null )repo.delete(result);

        }


        public Product Map(ProductInsertDTO prod)
        {
            Product obj = new Product();
            obj.Description = prod.Description;
            obj.CurrentPrice = prod.CurrentPrice;
            obj.Quantity = prod.Quantity;
            return obj;
        }



        public ProductDTO? Map(Product? prod)
        {
            if(prod == null) return null;
            ProductDTO obj = new ProductDTO();
            obj.Upc = prod.Upc;
            obj.Description = prod.Description;
            obj.CurrentPrice = prod.CurrentPrice;
            obj.Quantity = prod.Quantity;
            return obj;
        }


        public List<ProductDTO?>Map(List<Product> prod)
        {
            List<ProductDTO?> obj = new List<ProductDTO?>();
           foreach (var item in prod)
            {
                obj.Add(Map(item));
            }

            return obj;
        }

        public Product Map(ProductDTO prod)
        {
            Product obj = new Product();
            obj.Upc = prod.Upc;
            obj.Description = prod.Description;
            obj.CurrentPrice = prod.CurrentPrice;
            obj.Quantity = prod.Quantity;
            return obj;
        }
    }
}
