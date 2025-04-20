using System.Net;
using Domain.Exceptions;
using shared.ModelErrors;

namespace E_Commerce.MiddleWares
{
    public class GlobalExceptionHandlingMiddleWare
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionHandlingMiddleWare> _logger;

        public GlobalExceptionHandlingMiddleWare(RequestDelegate next, ILogger<GlobalExceptionHandlingMiddleWare> logger)
        {
            _logger = logger;
            _next = next;
        }
            
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch(Exception exception) 
            {
                _logger.LogError($"something went wrong");
                await HandleExceptionAsync(httpContext, exception);
            }
        } 

        public async Task HandleExceptionAsync(HttpContext httpContext , Exception exception)
        {
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            httpContext.Response.ContentType = "application/json";

            httpContext.Response.StatusCode = exception switch
            {
                NotFoundException => (int)HttpStatusCode.NotFound,
                UnAuthorizedException=> (int)HttpStatusCode.Unauthorized,
                RegisterValidationException => (int)HttpStatusCode.Unauthorized,

                    _=> (int)HttpStatusCode.InternalServerError
            };

            var response = new ErrorsDetails
            {
                statusCode = httpContext.Response.StatusCode,
                ErrorMsg=exception.Message
            }.ToString();

            await httpContext.Response.WriteAsync(response);
        }
    }
}
