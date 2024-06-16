using FLY.Business.Services;
using FLY.Business.Services.Implements;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FLY.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpPost("/api/v1/product/category/{categoryName}")]
        public async Task<IActionResult> GetProductsByCategory(string categoryName)
        {
            try
            {
                var result = await _productService.GetProductsByCategoryAsync(categoryName);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("/api/v1/product/{productName}")]
        public async Task<IActionResult> GetProductsByName(string productName)
        {
            try
            {
                var result = await _productService.GetProductsByNameAsync(productName);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
