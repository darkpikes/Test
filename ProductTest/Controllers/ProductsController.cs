using Microsoft.AspNetCore.Mvc;
using ProductTest.Models;
using ProductTest.Services;

namespace ProductTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {


        private readonly ILogger<ProductsController> _logger;
        private readonly IProductService _service;

        public ProductsController(ILogger<ProductsController> logger, IProductService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet()]
        [Route("products")]
        public List<ProductDTO> Get()
        {

            var result = _service.GetAll();
            if (result.Count == 0) { throw new Exception("No Results"); }
            return result;

            
        }

        [HttpGet()]
        [Route("product")]
        public ProductDTO Get(int UPC)
        {

            var result = _service.GetProduct(UPC);

            if(result == null) { throw new Exception("Not Found"); }


            return result;


        }

        [HttpPost()]
        public ProductDTO Create(ProductInsertDTO product)
        {

            var result = _service.InsertProduct(product);
            if (result == null) { throw new Exception("Cannot create product"); }

            return result;
        }

        [HttpPut()]
        public ProductDTO Edit(ProductDTO product)
        {

            var result = _service.EditProduct(product);
            if (result == null) { throw new Exception("Cannot found product"); }

            return result;
        }

        [HttpDelete()]
        public void Delete(int product)
        {
             _service.DeleteProduct(product);
        }
    }
}