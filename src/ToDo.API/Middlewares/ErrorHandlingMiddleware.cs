using ToDo.Domain.Exceptions;

namespace TodoManager.API.Middlewares;


public class ErrorHandlingMiddleware : IMiddleware
{
    private readonly ILogger<ErrorHandlingMiddleware> _logger;

    public ErrorHandlingMiddleware(ILogger<ErrorHandlingMiddleware> logger)
    {
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next.Invoke(context);
        }
        catch (NotFoundException notFound)
        {
            context.Response.StatusCode = 404;
            await context.Response.WriteAsync(notFound.Message);
            _logger.LogWarning(notFound.Message);

        }
        catch (ForbidException ex)
        {
            context.Response.StatusCode = 403;
            await context.Response.WriteAsJsonAsync(ex.Message);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message, ex);
            context.Response.StatusCode = 500;
            await context.Response.WriteAsJsonAsync(ex.Message);
        }
    }
}
