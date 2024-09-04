
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using ToDo.Domain.Entities;
using ToDo.Application.Interfaces;
using ToDo.Domain.Repositories;
using ToDo.Infrastructure.Repositories;
using ToDo.Infrastructure.Authentication;
using ToDo.Infrastructure.Persistance;


namespace ToDo.Infrastructure.Extensions;
public static class ServiceCollectionExtensions
{
    public static void AddInfrasturcture(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ToDoManagerDbContext>(options => 
                                                 options.UseSqlServer(configuration.GetConnectionString("ToDoDb")));

        services.AddIdentityCore<User>()
                .AddEntityFrameworkStores<ToDoManagerDbContext>();


        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    var tokenKey = configuration["TokenKey"] ?? throw new Exception("Cannot access tokenKey from appsettings");
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(tokenKey)
                        ),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };

                });

        services.AddScoped<ITokenGenerator, JwtTokenGenerator>();
        services.AddScoped<IAuthenticationService, AuthenticationService>();

        services.AddScoped<IUsersRepository, UsersRepository>();
        services.AddScoped<IToDoItemsRepository, ToDoItemsRepository>();




    }
}
