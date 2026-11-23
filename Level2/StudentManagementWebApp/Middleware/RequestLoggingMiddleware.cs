
using System.Diagnostics;

namespace StudentManagementWebApp.Middleware
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestLoggingMiddleware> _logger;

        public RequestLoggingMiddleware(
            RequestDelegate next,
            ILogger<RequestLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var stopwatch = Stopwatch.StartNew();

            _logger.LogInformation(
                "Incoming request: {Method} {Path}",
                context.Request.Method,
                context.Request.Path
            );

            await _next(context);

            stopwatch.Stop();

            _logger.LogInformation(
                "Response status: {StatusCode}. Time: {ElapsedMilliseconds} ms",
                context.Response.StatusCode,
                stopwatch.ElapsedMilliseconds
            );
        }
    }
}
