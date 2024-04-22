using GeekShopping.ProductApi.Data.DTO;
using GeekShopping.ProductApi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.ProductApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> FindAll()
        {
            var products = await _productRepository.FindAll();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> FindById(long id)
        {
            var product = await _productRepository.FindById(id);
            if (product.Id < 1) return NotFound();
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<ProductDto>> Create(ProductDto productDto)
        {
            if (productDto == null) return BadRequest();
            var product = await _productRepository.Create(productDto);
            return Ok(product);
        }

        [HttpPut]
        public async Task<ActionResult<ProductDto>> Update(ProductDto productDto)
        {
            if (productDto == null) return BadRequest();
            var product = await _productRepository.Update(productDto);
            return Ok(product);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            var status = await _productRepository.Delete(id);
            if (!status) return BadRequest();
            return Ok(status);
        }
    }
}
