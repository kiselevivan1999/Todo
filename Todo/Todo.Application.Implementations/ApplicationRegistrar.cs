using Microsoft.Extensions.DependencyInjection;
using Todo.Application.Abstractions.Services;
using Todo.Application.Implementations.Services;

namespace Todo.Application.Implementations;

public static class ApplicationRegistrar
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services) 
    {
        services.AddScoped<ITodoItemService, TodoItemService>();
        return services;
    }
}
