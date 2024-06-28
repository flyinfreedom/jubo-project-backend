using jubo_project_api.Helpers;
using jubo_project_api.Infrastructure;
using jubo_project_api.Infrastructure.Repositories;
using jubo_project_api.Middlewares;
using jubo_project_api.Services;
using jubo_project_api.Services.Interface;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddScoped<PatientOrderContext>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IPatientRepository, PatientRepository>();
builder.Services.AddScoped<OrderService>();
builder.Services.AddScoped<PatientService>();
builder.Services.AddScoped<MongoDbHelper>();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseWhen(httpContext => httpContext.Request.Path.StartsWithSegments("/api"),
    subApp =>
    {
        subApp.UseMiddleware<AuthMiddleware>();
        subApp.UseMiddleware<ExceptionMiddleware>();
    });

app.MapControllers();

app.Run();