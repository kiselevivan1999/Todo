using Todo.Infrastructure.EntityFramework;
using Todo.Infrastructure.Repositories.Implementations;
using Todo.Application.Implementations;

namespace Todo.Api;

public static class Registrar
{
    public static IServiceCollection AddServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddControllers();
        services.AddSwaggerGen();

        services.AddApplicationServices();
        services.AddRepositoriesInfrastructure(configuration);
        services.AddEntityFrameworkInfrastructure(configuration);

        return services;
    }
}
