using System.Net;

namespace LuftballonAt.Web.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlingMiddleware> _logger;


        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext httpContext, IServiceProvider serviceProvider)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                await HandleExceptionsAsync(httpContext, serviceProvider, ex);
            }
        }


        public async Task HandleExceptionsAsync(HttpContext httpContext, IServiceProvider serviceProvider, Exception exception)
        {
            _logger.LogError(exception, "Unhandled exception occurred while processing the request");

            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            await httpContext.Response.WriteAsync(new
            {
                status = httpContext.Response.StatusCode,
                message = "Ein interner Serverfehler ist aufgetreten",
                detail = exception.Message,
                instance = httpContext.Request.Path,

            }.ToString());
        }
    }
}
