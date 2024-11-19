using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ECommerceGateway.Middleware
{
    public class AuthenticationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;

        public AuthenticationMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            _configuration = configuration;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Skip authentication for login endpoint
            if (context.Request.Path.StartsWithSegments("/user/login"))
            {
                await _next(context);
                return;
            }

            // Check for Authorization header
            if (!context.Request.Headers.ContainsKey("Authorization"))
            {
                context.Response.StatusCode = 401;
                return;
            }

            var token = context.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            
            try
            {
                // JWT validation logic here
                await _next(context);
            }
            catch
            {
                context.Response.StatusCode = 401;
            }
        }
    }
}
