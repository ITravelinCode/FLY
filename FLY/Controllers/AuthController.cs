using FLY.Business.Models.Account;
using FLY.Business.Services;
using FLY.Business.Services.Implements;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FLY.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [AllowAnonymous]
        [HttpPost("/api/v1/auth")]
        public async Task<IActionResult> Login([FromBody] AuthRequest loginInfo)
        {
            var account = new AuthResponse
            {
                Email = loginInfo.Email,

            };
            bool check = await _authService.AuthenticateAccountAdvanced(account);
            if (check)
            {
                return Ok("Email has been sent, please check email to verify your account, if you don't see it, check your spam");
            }
            else
            {
                return BadRequest("Something went wrong");
            }
        }
    }
}
