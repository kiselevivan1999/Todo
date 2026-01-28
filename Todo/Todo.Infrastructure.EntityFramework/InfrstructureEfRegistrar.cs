using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Todo.Infrastructure.EntityFramework.Context;

namespace Todo.Infrastructure.EntityFramework;

public static class InfrstructureEfRegistrar
{
    public static IServiceCollection AddEntityFrameworkInfrastructure(this IServiceCollection services,
        IConfiguration configuration) 
    {
        services.AddDbContext<TodoDbContext>(options =>
        {
            var databaseName = configuration["Database:InMemoryName"];
            if (databaseName is null)
                throw new ArgumentNullException("В конфигурации не найдено имя базы");

            options.UseInMemoryDatabase(databaseName);
        });
        return services;
    }
}
