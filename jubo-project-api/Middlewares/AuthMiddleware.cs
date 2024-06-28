namespace jubo_project_api.Middlewares;

public class AuthMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
{
    public async Task InvokeAsync(HttpContext context)
    {
        // 實作 api authentication 用
        if (context.Request.Headers.Authorization != "Bearer jubo-project")
        {
            context.Response.StatusCode = 401;
            return;
        }
        await next(context);
    }
}