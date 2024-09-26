using ProductTest.Models;

namespace ProductTest.Services
{
    public interface IProductService
    {
        ProductDTO? GetProduct(int UPC);

        List<ProductDTO?> GetAll();

        ProductDTO? InsertProduct(ProductInsertDTO prod);

        ProductDTO? EditProduct(ProductDTO prod);

        void DeleteProduct(int UPC);
    }
}
