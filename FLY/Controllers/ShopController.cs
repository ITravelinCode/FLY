using FLY.Business.Services;
using FLY.Business.Services.Implements;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FLY.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopController : ControllerBase
    {
        private readonly IShopService _shopService;

        public ShopController(IShopService shopService)
        {
            _shopService = shopService;
        }

        [HttpPost("/api/v1/shop")]
        public async Task<IActionResult> GetShopByName([FromQuery] string shopName)
        {
            try
            {
                var result = await _shopService.GetShopByNameAsync(shopName);
                if(!result.Any())
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        //[HttpGet("/api/v1/shop")]
        //public async Task<IActionResult> GetShopByAccountId()
        //{

        //}
    }
}
