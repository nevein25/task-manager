using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using ToDo.Application.Interfaces;
using ToDo.Application.LiveToDoItems;
using ToDo.Application.Users;

namespace ToDo.Application.Extensions;
public static class ServiceCollectionExtensions
{
    public static void AddApplication(this IServiceCollection services)
    {
        var applicationAssembly = typeof(ServiceCollectionExtensions).Assembly;

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(applicationAssembly));

        services.AddValidatorsFromAssembly(applicationAssembly)
                .AddFluentValidationAutoValidation();

        services.AddAutoMapper(applicationAssembly);

        services.AddScoped<IUserContext, UserContext>();
        services.AddHttpClient<ILiveToDoItemsService, LiveToDoItemsService>();

        services.AddHttpContextAccessor();
    }
}
