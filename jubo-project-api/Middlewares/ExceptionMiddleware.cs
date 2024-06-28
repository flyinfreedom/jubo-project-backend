using jubo_project_api.Models;

namespace jubo_project_api.Middlewares;


public class ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            logger.LogError(ex.Message);
            var exceptionResponse = HandleException(ex);
            context.Response.StatusCode = exceptionResponse.StatusCode;
            await context.Response.WriteAsJsonAsync(exceptionResponse);
        }
    }

    private ExceptionResponse HandleException(Exception ex)
    {
        // 可實作 handle exception，將自定義的 exception 做處理後傳回至前端
        return new ExceptionResponse();
    }
}
