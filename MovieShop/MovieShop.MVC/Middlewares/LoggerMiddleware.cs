﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace MovieShop.MVC.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class LoggerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<LoggerMiddleware> _Logger;

        public LoggerMiddleware(RequestDelegate next, ILogger<LoggerMiddleware> logger)
        {
            _next = next;
            _Logger = logger;
        }

        public Task Invoke(HttpContext httpContext)
        {
            _Logger.LogInformation("Inside the logger");
            var ipAddress = httpContext.Connection?.RemoteIpAddress?.ToString();
            var datetime = DateTime.Now;

            _Logger.LogInformation("Request date: {0}", datetime.ToString());
            _Logger.LogInformation("Ip Address: {0}", ipAddress);
            if (httpContext.User.Identity != null && httpContext.User.Identity.IsAuthenticated)
            {
                var email = httpContext?.User.Claims
            .FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;

                var fullname = httpContext?.User.Claims
                                      .FirstOrDefault(c => c.Type == ClaimTypes.GivenName)?.Value + " " +
                                  httpContext?.User.Claims
                                      .FirstOrDefault(c => c.Type == ClaimTypes.Surname)?.Value;

                // log this information Database, text file, json file
                // System I/O...I can use this one....
                // 3rd party logging frameworks...SeriLog, Nlog
                // ASP.NET Core has built-in functionality for logging, MS provieded us with interfaces for logging.
                // ILogger using Microsoft.Extensions.Logging;
                // login
                _Logger.LogInformation("EmailAddress: {0}", email);
                _Logger.LogInformation("Name: {0}", fullname);
               

            }

            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseLoggerMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LoggerMiddleware>();
        }
    }
}
