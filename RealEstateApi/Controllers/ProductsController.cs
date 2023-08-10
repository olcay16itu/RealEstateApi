using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstateApi.Repositories.CategoryRepository;
using RealEstateApi.Repositories.ProductRepository;

namespace RealEstateApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> getAllProducts()
        {
            var values = await productRepository.GetAllAsync();
            return Ok(values);
        }

        [HttpGet("getAllProductsWithCategory")]
        public async Task<IActionResult> getAllProductsWithCategory()
        {
            var values = await productRepository.GetAllProductWithCategory();
            return Ok(values);
        }
    }
}
