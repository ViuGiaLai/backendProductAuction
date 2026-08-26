using Microsoft.AspNetCore.Http;

namespace WebApplication1.Middleware;

public class JwtMiddleware
{
    private readonly RequestDelegate _next;

    public JwtMiddleware(RequestDelegate next)
    {
        _next = next;
    }
}
