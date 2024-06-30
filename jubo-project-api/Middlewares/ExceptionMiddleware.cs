using jubo_project_api.Exceptions;
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
            //-- 將自定義的 Exception 另外處理
            if (ex is CustomException)
            {
                var customException = (ex as CustomException);                 
                context.Response.StatusCode = customException.StatusCode;
                await context.Response.WriteAsJsonAsync(new ExceptionResponse { StatusCode = customException.StatusCode, Message = customException.Message });
                return;
            }

            throw;
        }
    }
}
