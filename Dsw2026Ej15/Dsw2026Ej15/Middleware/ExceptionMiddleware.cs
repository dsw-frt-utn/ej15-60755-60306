using Dsw2026Ej15.Domain.Exceptions;
using System.Net;
using System.Text.Json;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IHostEnvironment _env;

    public ExceptionMiddleware(RequestDelegate next, IHostEnvironment env)
    {
        _next = next;
        _env = env;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    public async Task HandleExceptionAsync(HttpContext context, Exception ex)
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
        else
        {
            status = HttpStatusCode.InternalServerError;
            message = _env.IsDevelopment()
                ? $"{ex.GetType().Name}: {ex.Message}"
                : "Ocurrio un error inesperado";
        }

        var result = JsonSerializer.Serialize(new { error = message });
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)status;
        await context.Response.WriteAsync(result);
    }
}