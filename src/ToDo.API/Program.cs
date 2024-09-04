
using TodoManager.API.Extensions;
using ToDo.Application.Extensions;
using ToDo.Infrastructure.Extensions;
using TodoManager.API.Middlewares;


namespace TodoManager.API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.AddPresentation();
        builder.Services.AddApplication();
        builder.Services.AddInfrasturcture(builder.Configuration);

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();
        app.UseMiddleware<ErrorHandlingMiddleware>();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
