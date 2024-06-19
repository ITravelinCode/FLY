using Microsoft.Extensions.Caching.Memory;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace FLY.Business.Middlewares
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;

        public JwtMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, IMemoryCache cache)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            if (token != null)
            {
                var jwtToken = new JwtSecurityTokenHandler().ReadJwtToken(token);
                var email = jwtToken.Claims.FirstOrDefault(c => c.Type == "email")?.Value;
                if (email != null)
                {
                    var sessionId = jwtToken.Claims.FirstOrDefault(c => c.Type == "sessionId")?.Value;
                    var cacheKey = $"Account_{email}";
                    if(cache.TryGetValue(cacheKey, out string? cachedSessionId) && cachedSessionId == sessionId) 
                    {
                        await _next(context);
                        return;
                    }
                    else
                    {
                        context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                        return;
                    }
                }
            }
            await _next(context);
        }
    }
}
