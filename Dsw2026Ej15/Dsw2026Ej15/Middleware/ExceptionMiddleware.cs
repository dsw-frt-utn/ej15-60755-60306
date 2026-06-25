using Dsw2026Ej15.Api.Exceptions;
using System.Net;
using System.Text.Json;

namespace Dsw2026Ej15.Api.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context); 
            }
            catch (Exception ex)
            {
                HandleExceptionAsync(context,ex);
                
            }
           


        }
        public async Task HandleExceptionAsync(HttpContext context,Exception ex)
        {
            HttpStatusCode status;
            string message;
            if (ex is ValidationException ve)
            {
                status = HttpStatusCode.BadRequest;
                message = ve.Message;
            }
            else if (ex is EntityNotFoundException ve2)
            {
                status = HttpStatusCode.NotFound;
                message = ve2.Message;

            }
            else {
                status = HttpStatusCode.InternalServerError;
                message = "Ocurrio un error inesperado";
            }
            var result = JsonSerializer.Serialize(new { error=message});
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)status;
            await context.Response.WriteAsync(result);
        }

    }
}