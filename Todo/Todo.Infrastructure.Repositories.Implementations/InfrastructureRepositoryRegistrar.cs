using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Todo.Application.Repositories.Abstractions;
using Todo.Application.Repositories.Abstractions.Repositories;
using Todo.Infrastructure.Repositories.Implementations.Repositories;

namespace Todo.Infrastructure.Repositories.Implementations;

public static class InfrastructureRepositoryRegistrar
{
    public static IServiceCollection AddRepositoriesInfrastructure(
        this IServiceCollection services, IConfiguration configuration) 
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<ITodoItemRepository, TodoItemRepository>();

        return services;
    }
}
