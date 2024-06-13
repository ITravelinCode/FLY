using FLY.Business.Models.Account;
using Newtonsoft.Json;
using System.Net;
using System.Net.Mail;

namespace FLY.Business.Middlewares
{
    public class AuthMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if(context.Request.Path.StartsWithSegments("/api/v1/auth") && context.Request.Method == "POST")
            {
                context.Request.EnableBuffering();
                var body = await new StreamReader(context.Request.Body).ReadToEndAsync();
                context.Request.Body.Position = 0;

                var authRequest = JsonConvert.DeserializeObject<AuthRequest>(body);
                if(authRequest != null)
                {
                    var properties = body.GetType().GetProperties();
                    foreach (var property in properties)
                    {
                        var value = property.GetValue(authRequest);
                        if(value == null || (value is string && string.IsNullOrEmpty(value as string))) 
                        {
                            context.Response.StatusCode = StatusCodes.Status400BadRequest;
                            await context.Response.WriteAsync($"{property.Name} cannot be null or empty.");
                            return;
                        }
                    }
                    if (!isValidatedEmail(authRequest.Email))
                    {
                        context.Response.StatusCode = StatusCodes.Status400BadRequest;
                        await context.Response.WriteAsync("Email is not in a correct format.");
                        return;
                    }
                }
            }
            else
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsync("Request cannot be null");
                return;
            }
            await _next(context);
        }

        private bool isValidatedEmail(string emailAddress)
        {
            try
            {
                var addr = new MailAddress(emailAddress);
                return addr.Address == emailAddress;
            }
            catch
            {
                return false;
            }
        }
    }
}
