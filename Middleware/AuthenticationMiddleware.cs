using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quanlybanhang.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class AuthenticationMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthenticationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            if (httpContext.Request.Path.Value.StartsWith("/Acc/Login"))
            {
                // nếu có session thì sẽ nhảy vào trang hoa don/index 
                // ko thì ở trong home / index 
                if(httpContext.Session.GetString("KeyLogin") != null)
                {
                    httpContext.Response.Redirect("/Home/Index"); 
                }
            }
            else
            {
                if(httpContext.Session.GetString("KeyLogin") == null)
                {
                    httpContext.Response.Redirect("/Acc/Login");
                }
            }

            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class SessionMiddlewareExtensions
    {
        public static IApplicationBuilder UseSessionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AuthenticationMiddleware>();
        }
    }
}
